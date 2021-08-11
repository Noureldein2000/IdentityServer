using IdentityServer.DTOs;
using IdentityServer.Data.Entities;
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
        AccountDTO AddAccount(AccountDTO addDTO);
        AccountDTO EditAccount(AccountDTO editDTO);
        IEnumerable<AccountRequestDTO> GetAccountRequests(AccountRequestStatus status, int pagenumber, int pageSize);
        IEnumerable<AccountDTO> GetAccounts(int pagenumber, int pageSize);
        AccountRequestDTO GetAccountRequestsById(int id);
        AccountDTO GetAccountById(int id);
        AccountRequestStatus ChangeAccountRequestStatus(int id, AccountRequestStatus status, int createdBy);
        bool ChangeAccountStatus(int id, int updatedBy);
    }
}
