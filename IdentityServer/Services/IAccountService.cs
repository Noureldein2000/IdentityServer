using IdentityServer.DTOs;
using IdentityServer.Entities;
using IdentityServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface IAccountService
    {
        AccountRequestDTO Add(AccountRequestDTO addDTO);
        IEnumerable<AccountRequestDTO> GetAccountRequests(AccountRequestStatus status = AccountRequestStatus.UnderProcessing);
        AccountRequestStatus ChangeAccountRequestStatus(AccountRequestStatus status, int id);
    }
}
