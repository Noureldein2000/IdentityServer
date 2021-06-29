using IdentityServer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface ILoginService
    {
        Task<AuthorizationResponceDTO> ValidateUser(AccountChannelDTO model);
        Task<AuthorizationResponceDTO> ChangePassword(ChangePasswordDTO model);
    }
}
