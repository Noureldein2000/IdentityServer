using IdentityServer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface ILoginService
    {
        AuthorizationResponceDTO GetAccountChannelData(AccountChannelDTO model);
    }
}
