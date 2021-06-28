using IdentityServer.DTOs;
using IdentityServer.Entities;
using IdentityServer.Helpers;
using IdentityServer.Infrastructure;
using IdentityServer.Properties;
using IdentityServer.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class LoginService : ILoginService
    {
        private readonly IBaseRepository<UserToken, int> _userTokens;
        private readonly IBaseRepository<AccountChannelType, int> _accountChannelTypes;
        private readonly IBaseRepository<ChannelIdentifier, int> _channelIdentifires;
        private readonly IBaseRepository<AccountChannel, int> _accountChannels;
        private readonly IBaseRepository<OTP, int> _otps;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ISMSService _smsService;
        public LoginService(IBaseRepository<UserToken, int> userTokens,
            UserManager<ApplicationUser> userManager,
            IBaseRepository<AccountChannelType, int> accountChannelTypes,
            IBaseRepository<ChannelIdentifier, int> channelIdentifires,
            IBaseRepository<AccountChannel, int> accountChannels,
            IBaseRepository<OTP, int> otps,
            IUnitOfWork unitOfWork,
            IConfiguration configuration,
            ISMSService smsService)
        {
            _userTokens = userTokens;
            _userManager = userManager;
            _configuration = configuration;
            _accountChannelTypes = accountChannelTypes;
            _channelIdentifires = channelIdentifires;
            _accountChannels = accountChannels;
            _unitOfWork = unitOfWork;
            _smsService = smsService;
            _otps = otps;
        }
        public AuthorizationResponceDTO GetAccountChannelData(AccountChannelDTO model)
        {
            var account = _accountChannelTypes.Getwhere(a => a.AccountID == model.AccountId
                    && a.ChannelTypeID == model.ChannelTypeId).Select(a => new
                    {
                        a.ExpirationPeriod,
                        a.HasLimitedAccess,
                        a.Account.AccountTypeID,
                        a.Account.Name,
                        a.Account.AccountOwner.Mobile
                    }).FirstOrDefault();
            if (account == null)
                throw new AuthorizationException(Resources.NoAuth, ErrorCodes.Autorization.NoAuth);

            if (account.AccountTypeID == (int)AccountTypeStatus.Company && model.ChannelCategory == (int)ChannelCategoryStatus.API)
            {
                model.ChannelId = model.AccountIP;
            }

            var accountChannelType = _accountChannelTypes.Getwhere(a => a.AccountID == model.AccountId
                && a.ChannelTypeID == model.ChannelTypeId
                && a.Account.AccountChannels.Any(ac => ac.Status == ActiveStatus.True)
                && a.Account.AccountChannels.Any(ac =>
                ac.Channel.ChannelIdentifiers.Any(ci => ci.Status == ActiveStatus.True
                    && ci.Value == model.ChannelId
                ))).Select(act => new
                {
                    act.ExpirationPeriod,
                    act.HasLimitedAccess,
                    act.Account.AccountTypeID,
                    act.Account.Name,
                    act.ChannelType.Version
                }).FirstOrDefault();

            //if(accountChannelType == null)

            if (accountChannelType != null)
            {
                if (model.MustChangePassword)
                    throw new OkException(Resources.MustChangePassword, ErrorCodes.Autorization.MustChangePassword);
            }
            else if (accountChannelType == null && !account.HasLimitedAccess)
            {
                //check for first time login and send otp
                var identifier = _channelIdentifires.Getwhere(i => i.Value == model.ChannelId
                && i.Status == ActiveStatus.True
                && i.Channel.AccountChannels.Any(ac => ac.Status == ActiveStatus.True
                && ac.AccountID != model.AccountId)).FirstOrDefault();
                if (identifier == null)
                {
                    var channelAccountId = CreateAccountChannel(model.AccountId, model.ChannelId, model.UserId);
                    var otp = Statics.GenerateRandomNumeric(6);
                    CreateOTP(model.UserId, channelAccountId, model.LocalIP, model.AccountIP, otp);
                    _smsService.SendMessage($"Momkn OTP: {otp}", "E", account.Mobile);
                    throw new OkException(Resources.MustInputOTP, ErrorCodes.Autorization.MustInputOTP);
                }
                else
                {
                    throw new AuthorizationException(Resources.NoAuth, ErrorCodes.Autorization.NoAuth);
                }
            }
            return new AuthorizationResponceDTO
            {
                LocalDate = model.LocalDate,
                ServerDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")),
                AccountId = model.AccountId,
                Version = accountChannelType.Version == 0 ? "" : accountChannelType.Version.ToString(),
                ServiceListVersion = "7",
                AccountName = account.Name,
                AccountType = account.AccountTypeID.Value,
                ExpirationPeriod = account.ExpirationPeriod
            };
        }

        private int CreateAccountChannel(int accountId, string channelIdValue, int userId)
        {
            var channelId = _channelIdentifires.Getwhere(ci => ci.Value == channelIdValue).Select(ci => ci.ChannelID).FirstOrDefault();
            var channelAccount = _accountChannels.Add(new AccountChannel
            {
                AccountID = accountId,
                ChannelID = channelId,
                CreatedBy = userId,
            });
            _unitOfWork.SaveChanges();
            return channelAccount.ID;
        }
        private void CreateOTP(int userId, int accountChannelId, string localIP, string accountIP, string otpCode)
        {
            _otps.Add(new OTP
            {
                AccountChannelID = accountChannelId,
                AccountIP = accountIP,
                LocalIP = localIP,
                CreatedBy = userId,
                OTPCode = otpCode,
                SmsSequence = 1,
                UserID = userId,
                StatusID = 1
            });
            _unitOfWork.SaveChanges();
        }
    }
}
