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
        AccountRequestDTO AddAccountRequest(AccountRequestDTO addDTO);
        IEnumerable<AccountRequestDTO> GetAccountRequests(AccountRequestStatus status, int pagenumber, int pageSize);
        AccountRequestDTO GetAccountRequestsById(int id);
        AccountRequestStatus ChangeAccountRequestStatus( int id, AccountRequestStatus status, int createdBy);
    }
}
