using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Helpers;
using IdentityServer.Infrastructure;
using IdentityServer.Infrastructure.Utils;
using IdentityServer.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static IdentityServer.Infrastructure.Constants;

namespace IdentityServer.Services
{
    public class LoginService : ILoginService
    {
        private readonly IBaseRepository<UserToken, int> _userTokens;
        private readonly IBaseRepository<AccountChannelType, int> _accountChannelTypes;
        private readonly IBaseRepository<ChannelIdentifier, int> _channelIdentifires;
        private readonly IBaseRepository<AccountChannel, int> _accountChannels;
        private readonly IBaseRepository<AccountOwner, int> _accountOwner;
        private readonly IBaseRepository<OTP, int> _otps;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ISMSService _smsService;
        private readonly IStringLocalizer<AuthenticationResource> _localizer;
        public LoginService(IBaseRepository<UserToken, int> userTokens,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IBaseRepository<AccountChannelType, int> accountChannelTypes,
            IBaseRepository<ChannelIdentifier, int> channelIdentifires,
            IBaseRepository<AccountChannel, int> accountChannels,
            IBaseRepository<AccountOwner, int> accountOwner,
            IBaseRepository<OTP, int> otps,
            IUnitOfWork unitOfWork,
            IConfiguration configuration,
            ISMSService smsService,
            IStringLocalizer<AuthenticationResource> localizer)
        {
            _userTokens = userTokens;
            _userManager = userManager;
            _configuration = configuration;
            _accountChannelTypes = accountChannelTypes;
            _channelIdentifires = channelIdentifires;
            _accountChannels = accountChannels;
            _accountOwner = accountOwner;
            _unitOfWork = unitOfWork;
            _smsService = smsService;
            _otps = otps;
            _localizer = localizer;
            _roleManager = roleManager;
        }

        public async Task<AuthorizationResponceDTO> ValidateUser(AccountChannelLoginDTO model)
        {
            int otpId = 0;
            var user = await ValidateApplicationUser(model.Username, model.Password, model.AccountId.ToString());
            var tryAccount = int.TryParse(model.AccountId, out var accountId);
            var tryChannelType = int.TryParse(model.ChannelType, out var channelType);
            var tryChannelCategory = int.TryParse(model.ChannelCategory, out var channelCategory);

            if (!tryAccount || !tryChannelType || !tryChannelCategory)
            {
                throw new OkException(_localizer["FailedTry"].Value, ErrorCodes.FailedTry);
            }

            var account = _accountChannelTypes.Getwhere(a => a.AccountID == accountId
                && a.ChannelTypeID == channelType && a.Account.Active == true
                && a.Account.AccountChannels.Any(ac => ac.Status == AccountChannelStatus.Active
                && ac.Channel.ChannelIdentifiers.Value == model.ChannelId)).Select(a => new
                {
                    a.ExpirationPeriod,
                    a.HasLimitedAccess,
                    a.Account.AccountTypeProfile.AccountTypeID,
                    a.Account.Name,
                    a.Account.AccountOwner.Mobile
                }).FirstOrDefault();
            if (account == null)
                throw new AuthorizationException(_localizer["NoAuth"].Value, ErrorCodes.Autorization.NoAuth);

            if (account.AccountTypeID == (int)AccountTypeStatus.Company && channelCategory == (int)ChannelCategoryStatus.API)
            {
                model.ChannelId = model.AccountIP;
            }

            var accountChannelType = _accountChannelTypes.Getwhere(a => a.AccountID == accountId
                && a.ChannelTypeID == channelType
                && a.Account.AccountChannels.Any(ac => ac.Status == AccountChannelStatus.Active)
                && a.Account.AccountChannels.Any(ac =>
                ac.Channel.ChannelIdentifiers.Status == true
                    && ac.Channel.ChannelIdentifiers.Value == model.ChannelId
                )).Select(act => new
                {
                    act.ExpirationPeriod,
                    act.HasLimitedAccess,
                    act.Account.AccountTypeProfile.AccountTypeID,
                    act.Account.Name,
                    act.ChannelType.Version
                }).FirstOrDefault();

            //if(accountChannelType == null)

            if (accountChannelType != null)
            {
                if (user.MustChangePassword)
                    throw new OkException(_localizer["MustChangePassword"].Value, ErrorCodes.ChangePassword.MustChangePassword);
            }
            else if (accountChannelType == null && !account.HasLimitedAccess)
            {
                //check for first time login and send otp
                var identifier = _channelIdentifires.Getwhere(i => i.Value == model.ChannelId
                && i.Status == true
                && i.Channel.AccountChannels.Any(ac => ac.Status == AccountChannelStatus.Active
                && ac.AccountID != accountId)).FirstOrDefault();
                if (identifier == null)
                {
                    var channelAccountId = CreateAccountChannel(accountId, model.ChannelId, user.UserId);
                    otpId = SendOTP(user.UserId, channelAccountId, model.LocalIP, model.AccountIP, account.Mobile);
                    throw new OkException(_localizer["MustInputOTP"], ErrorCodes.Autorization.MustInputOTP);
                }
                else
                {
                    throw new AuthorizationException(_localizer["NoAuth"].Value, ErrorCodes.Autorization.NoAuth);
                }
            }

            var tokenData = await GetUserToken(user, model.AccountId.ToString(), model.ChannelId, account.ExpirationPeriod);
            return new AuthorizationResponceDTO
            {
                Id = otpId,
                Token = tokenData.Token,
                Permissions = tokenData.Permissions,
                LocalDate = model.LocalDate,
                ServerDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")),
                AccountId = accountId,
                Version = accountChannelType.Version == 0 ? "" : accountChannelType.Version.ToString(),
                ServiceListVersion = "7",
                AccountName = account.Name,
                AccountType = account.AccountTypeID,
                ExpirationPeriod = account.ExpirationPeriod,
                Code = ErrorCodes.Success,
                Message = _localizer["Success"].Value
            };


        }
        public async Task<AuthorizationResponceDTO> ChangePassword(ChangePasswordDTO model)
        {
            var user = await ValidateApplicationUser(model.Username, model.Password, model.AccountId.ToString());
            var account = _accountChannelTypes.Getwhere(a => a.AccountID == model.AccountId
                    && a.ChannelTypeID == model.ChannelType).Select(a => new
                    {
                        a.ExpirationPeriod,
                        a.HasLimitedAccess,
                        a.Account.AccountTypeProfile.AccountTypeID,
                        a.Account.Name,
                        a.Account.AccountOwner.Mobile
                    }).FirstOrDefault();
            if (account == null)
                throw new AuthorizationException(_localizer["NoAuth"].Value, ErrorCodes.Autorization.NoAuth);

            var accountChannelType = _accountChannelTypes.Getwhere(a => a.AccountID == model.AccountId
                   && a.ChannelTypeID == model.ChannelType
                   && a.Account.AccountChannels.Any(ac => ac.Status == AccountChannelStatus.Active)
                   && a.Account.AccountChannels.Any(ac => ac.Channel.ChannelIdentifiers.Status == true
                && ac.Channel.ChannelIdentifiers.Value == model.ChannelId
           )).Select(act => new
           {
               act.ExpirationPeriod,
               act.HasLimitedAccess,
               act.Account.AccountTypeProfile.AccountTypeID,
               act.Account.Name,
               act.ChannelType.Version
           }).FirstOrDefault();
            IdentityResult result = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
            if (!result.Succeeded)
                throw new OkException(_localizer["FailedTry"].Value, ErrorCodes.FailedTry);

            user.MustChangePassword = false;
            _unitOfWork.SaveChanges();
            var tokenData = await GetUserToken(user, model.AccountId.ToString(), model.ChannelId, account.ExpirationPeriod);
            return new AuthorizationResponceDTO
            {
                Token = tokenData.Token,
                Permissions = tokenData.Permissions,
                LocalDate = DateTime.Now,
                ServerDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")),
                AccountId = model.AccountId,
                Version = accountChannelType.Version == 0 ? "" : accountChannelType.Version.ToString(),
                ServiceListVersion = "7",
                AccountName = account.Name,
                AccountType = account.AccountTypeID,
                ExpirationPeriod = account.ExpirationPeriod,
                Code = ErrorCodes.Success,
                Message = _localizer["Success"].Value
            };

            //throw new AuthorizationException(Resources.InvalidPasswordFormat, ErrorCodes.ChangePassword.InvalidPassword);
            //throw new OkException(Resources.CannotChangePassword, ErrorCodes.ChangePassword.CannotChangeOldPassword);
        }
        public async Task<AuthorizationResponceDTO> ConfirmOTP(ConfirmOTPDTO model)
        {
            var user = await ValidateApplicationUser(model.Username, model.Password, model.AccountId.ToString());

            if (user.MustChangePassword)
                throw new OkException(_localizer["MustChangePassword"].Value, ErrorCodes.ChangePassword.MustChangePassword);

            if (!int.TryParse(model.Id, out var otpId) || !int.TryParse(model.AccountId, out var accountId))
                throw new OkException(_localizer["FailedTry"].Value, ErrorCodes.FailedTry);

            var otp = _otps.Getwhere(o => o.ID == otpId
            && o.OTPCode == model.OTP && o.StatusID == 1
            && o.UserID == user.UserId
            && o.AccountChannel.Channel.ChannelIdentifiers.Value == model.ChannelId).FirstOrDefault();
            if (otp == null)
                throw new OkException(_localizer["Thetimehasexceedetthelimit"].Value, ErrorCodes.OTP.TheTimeExceededLimit);

            if (otp.CreationDate.Subtract(DateTime.Now).Seconds > 60)
                throw new OkException(_localizer["FailedTry"].Value, ErrorCodes.FailedTry);

            var channelIdentifier = _channelIdentifires.Getwhere(ch => ch.Value == model.ChannelId).FirstOrDefault();
            channelIdentifier.Status = true;
            channelIdentifier.UpdatedBy = user.UserId;

            var accountChannel = _accountChannels.Getwhere(ac =>
                ac.Channel.ChannelIdentifiers.ID == channelIdentifier.ID).FirstOrDefault();
            accountChannel.Status = AccountChannelStatus.Active;

            otp.StatusID = 2;
            otp.UpdatedBy = user.UserId;
            _unitOfWork.SaveChanges();

            var expiry = _accountChannelTypes.Getwhere(ac => ac.AccountID == accountId)
                .Select(ac => ac.ExpirationPeriod).FirstOrDefault();

            var tokenData = await GetUserToken(user, model.AccountId.ToString(), model.ChannelId, expiry);
            return new AuthorizationResponceDTO
            {
                AccountId = accountId,
                Code = ErrorCodes.Success,
                Message = _localizer["Success"].Value,
                Token = tokenData.Token,
                Permissions = tokenData.Permissions,
            };
        }
        public async Task<AuthorizationResponceDTO> ResendOTP(ConfirmOTPDTO model)
        {
            if (!int.TryParse(model.Id, out var otpId) || !int.TryParse(model.AccountId, out var accountId))
                throw new OkException(_localizer["FailedTry"].Value, ErrorCodes.FailedTry);

            var user = await ValidateApplicationUser(model.Username, model.Password, model.AccountId);

            var otp = _otps.Getwhere(o => o.OriginalOTPID == otpId && o.UserID == user.UserId)
                .FirstOrDefault();

            if (otp != null)
                throw new OkException(_localizer["Trialshaveexceededthelimit"].Value, ErrorCodes.OTP.Trialshaveexceededthelimit);

            var accountChannel = _accountChannels.Getwhere(ac =>
                ac.Channel.ChannelIdentifiers.Value == model.ChannelId).Select(ac => new
                {
                    ac.ID,
                    ac.Account.AccountOwner.Mobile
                }).FirstOrDefault();

            SendOTP(user.UserId, accountChannel.ID, model.LocalIP, model.AccountIP, accountChannel.Mobile, 2, otpId);
            var expiry = _accountChannelTypes.Getwhere(ac => ac.AccountID == accountId)
                .Select(ac => ac.ExpirationPeriod).FirstOrDefault();
            var tokenData = await GetUserToken(user, model.AccountId.ToString(), model.ChannelId, expiry);
            return new AuthorizationResponceDTO
            {
                Id = otpId,
                AccountId = accountId,
                Code = ErrorCodes.Success,
                Message = _localizer["Success"].Value,
                Token = tokenData.Token,
                Permissions = tokenData.Permissions,
            };
        }
        public async Task<bool> ResetUserPassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) throw new IdentityException(_localizer["ThisUserIsNotFound"].Value, "-1");

            string password = GetData.GenerateRandomNumeric(6).ToString();
            user.MustChangePassword = false;
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, password);

            if (result.Succeeded)
            {
                string userName = user.UserName;
                string accountId = user.ReferenceID;
                string mobileNumber = _accountOwner.Getwhere(x => x.AccountID == int.Parse(accountId)).FirstOrDefault().Mobile;
                string textSMS = CreateSMSText(userName, password, accountId);
                _smsService.SendMessage(textSMS, mobileNumber);
                return true;
            }

            return !result.Succeeded;
        }

        //Helper Method
        #region Helper Method
        private async Task<ApplicationUser> ValidateApplicationUser(string username, string password, string accountId)
        {
            var user = _userManager.Users.Where(u => u.UserName == username && u.ReferenceID == accountId).FirstOrDefault();
            var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (user != null && result == PasswordVerificationResult.Success)
            {
                if (user.LockoutEnabled && user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTime.Now)
                    throw new AuthorizationException(_localizer["NoAuth"].Value, ErrorCodes.Autorization.NoAuth);
                return user;
            }
            throw new AuthorizationException(_localizer["NoAuth"].Value, ErrorCodes.Autorization.NoAuth);
        }
        private async Task<UserTokenRoleDTO> GetUserToken(ApplicationUser user, string accountId, string channelId, int expiry)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);

            var authClaims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserId.ToString()) };
            var allowdClaims = new List<Claim>();

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            foreach (var userRole in userRoles)
            {
                var role = await _roleManager.FindByNameAsync(userRole);
                var userRoleClaims = await _roleManager.GetClaimsAsync(role);
                foreach (var userRoleClaim in userRoleClaims)
                {
                    if (!userClaims.Where(uc => uc.Type == "Deny")
                        .Select(uc => new { denyList = uc.Value.Split('.').ToList() })
                        .Any(uc => uc.denyList[1] == userRoleClaim.Value.Split('.')[1]
                        && uc.denyList[2] == userRoleClaim.Value.Split('.')[2])
                        )
                    {
                        authClaims.Add(new Claim(userRoleClaim.Type, userRoleClaim.Value));
                        allowdClaims.Add(new Claim(userRoleClaim.Type, userRoleClaim.Value));
                    }
                }
            }

            //foreach (var claim in userClaims)
            //{
            //    authClaims.Add(new Claim(claim.Type, claim.Value));
            //}
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
                Permissions = allowdClaims.Select(s => s.Value.Split('.')[1] + "." + s.Value.Split('.')[2]).ToArray()
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
        private int CreateOTP(int userId, int accountChannelId, string localIP, string accountIP, string otpCode, int sequence = 1, int? originalID = null)
        {
            var opt = _otps.Add(new OTP
            {
                AccountChannelID = accountChannelId,
                AccountIP = accountIP,
                LocalIP = localIP,
                CreatedBy = userId,
                OTPCode = otpCode,
                SmsSequence = sequence,
                UserID = userId,
                StatusID = 1,
                OriginalOTPID = originalID
            });
            _unitOfWork.SaveChanges();
            return opt.ID;
        }
        private int SendOTP(int userId, int accountChannelId, string localIP, string accountIP, string mobile, int sequence = 1, int? originalID = null)
        {
            var otp = Statics.GenerateRandomNumeric(6);
            int otpId = CreateOTP(userId, accountChannelId, localIP, accountIP, otp, sequence, originalID);
            _smsService.SendMessage($"Momkn OTP: {otp}", "E", mobile);
            return otpId;
        }
        private string CreateSMSText(string name, string password, string accountId)
        {
            return "اسم المستخدم :" + name + "وكلمة المرور :" + password + " ورقم المركز: " + accountId;
        }
    }
    #endregion
}
