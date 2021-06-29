﻿using IdentityServer.DTOs;
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
using static IdentityServer.Models.Constants;

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

        public async Task<AuthorizationResponceDTO> ChangePassword(ChangePasswordDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var account = _accountChannelTypes.Getwhere(a => a.AccountID == model.AccountId
                        && a.ChannelTypeID == model.ChannelType).Select(a => new
                        {
                            a.ExpirationPeriod,
                            a.HasLimitedAccess,
                            a.Account.AccountTypeID,
                            a.Account.Name,
                            a.Account.AccountOwner.Mobile
                        }).FirstOrDefault();
                if (account == null)
                    throw new AuthorizationException(Resources.NoAuth, ErrorCodes.Autorization.NoAuth);

                var accountChannelType = _accountChannelTypes.Getwhere(a => a.AccountID == model.AccountId
                       && a.ChannelTypeID == model.ChannelType
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
                IdentityResult result = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
                if (!result.Succeeded)
                    throw new AuthorizationException(Resources.InvalidPasswordFormat, ErrorCodes.ChangePassword.InvalidPassword);

                user.MustChangePassword = false;
                _unitOfWork.SaveChanges();
                var tokenData = await GetUserToken(user, model.AccountId.ToString(), model.ChannelId, account.ExpirationPeriod);
                return new AuthorizationResponceDTO
                {
                    Token = tokenData.Token,
                    Privilages = tokenData.Privilages,
                    LocalDate = DateTime.Now,
                    ServerDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")),
                    AccountId = model.AccountId,
                    Version = accountChannelType.Version == 0 ? "" : accountChannelType.Version.ToString(),
                    ServiceListVersion = "7",
                    AccountName = account.Name,
                    AccountType = account.AccountTypeID.Value,
                    ExpirationPeriod = account.ExpirationPeriod,
                    Code = ErrorCodes.Success,
                    Message = Resources.Success
                };
            }
            throw new OkException(Resources.CannotChangePassword, ErrorCodes.ChangePassword.CannotChangeOldPassword);
        }

        public async Task<AuthorizationResponceDTO> GetAccountChannelData(AccountChannelDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                if (user.LockoutEnabled && user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTime.Now)
                    throw new AuthorizationException(Resources.NoAuth, ErrorCodes.Autorization.NoAuth);

                var account = _accountChannelTypes.Getwhere(a => a.AccountID == model.AccountId
                    && a.ChannelTypeID == model.ChannelType).Select(a => new
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
                    && a.ChannelTypeID == model.ChannelType
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
                    if (user.MustChangePassword)
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
                        var channelAccountId = CreateAccountChannel(model.AccountId, model.ChannelId, user.UserId);
                        var otp = Statics.GenerateRandomNumeric(6);
                        CreateOTP(user.UserId, channelAccountId, model.LocalIP, model.AccountIP, otp);
                        _smsService.SendMessage($"Momkn OTP: {otp}", "E", account.Mobile);
                        throw new OkException(Resources.MustInputOTP, ErrorCodes.Autorization.MustInputOTP);
                    }
                    else
                    {
                        throw new AuthorizationException(Resources.NoAuth, ErrorCodes.Autorization.NoAuth);
                    }
                }

                var tokenData = await GetUserToken(user, model.AccountId.ToString(), model.ChannelId, account.ExpirationPeriod);
                return new AuthorizationResponceDTO
                {
                    Token = tokenData.Token,
                    Privilages = tokenData.Privilages,
                    LocalDate = model.LocalDate,
                    ServerDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")),
                    AccountId = model.AccountId,
                    Version = accountChannelType.Version == 0 ? "" : accountChannelType.Version.ToString(),
                    ServiceListVersion = "7",
                    AccountName = account.Name,
                    AccountType = account.AccountTypeID.Value,
                    ExpirationPeriod = account.ExpirationPeriod,
                    Code = ErrorCodes.Success,
                    Message = Resources.Success
                };
            }
            throw new AuthorizationException(Resources.NoAuth, ErrorCodes.Autorization.NoAuth);
        }
        private async Task<UserTokenRoleDTO> GetUserToken(ApplicationUser user, string accountId, string channelId, int expiry)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var userClaims = _userManager.GetClaimsAsync(user).Result.Where(c => c.Value == AvaliableClaimValues.True);
            var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    };
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            foreach (var claim in userClaims)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, claim.Type));
            }
            authClaims.Add(new Claim("channel_id", channelId));
            authClaims.Add(new Claim("account_id", accountId));
            var authSigninKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetValue<string>("IdentityServer:Secret")));
            var token = new JwtSecurityToken
            (
                issuer: _configuration.GetValue<string>("IdentityServer:Issuer"),
                audience: _configuration.GetValue<string>("IdentityServer:audience"),
                claims: authClaims,
                expires: DateTime.Now.AddDays(expiry),
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
             );
            return new UserTokenRoleDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Privilages = userClaims.Where(s => s.Value == AvaliableClaimValues.True)
                                                    .Select(s => s.Type).ToArray()
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
