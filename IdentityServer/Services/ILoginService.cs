using IdentityServer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface ILoginService
    {
        Task<AuthorizationResponceDTO> ValidateUser(AccountChannelLoginDTO model);
        Task<AuthorizationResponceDTO> ChangePassword(ChangePasswordDTO model);
        Task<AuthorizationResponceDTO> ConfirmOTP(ConfirmOTPDTO model);
        Task<AuthorizationResponceDTO> ResendOTP(ConfirmOTPDTO model);
        Task<bool> ResetUserPassword(string id);
    }
}
