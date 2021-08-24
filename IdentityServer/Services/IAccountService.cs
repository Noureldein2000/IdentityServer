using IdentityServer.DTOs;
using IdentityServer.Data.Entities;
using IdentityServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Models;

namespace IdentityServer.Services
{
    public interface IAccountService
    {
        AccountRequestDTO AddAccountRequest(AccountRequestDTO addDTO);
        AccountDTO AddAccount(AccountDTO addDTO);
        AccountDTO EditAccount(AccountDTO editDTO);
        IEnumerable<AccountRequestDTO> GetAccountRequests(AccountRequestStatus status, int pagenumber, int pageSize);
        PagedResult<AccountDTO> GetAccounts(int pagenumber, int pageSize);
        AccountRequestDTO GetAccountRequestsById(int id);
        AccountDTO GetAccountById(int id);
        AccountChannelTypeDTO GetAccountChannelTypeById(int id);
        AccountRequestStatus ChangeAccountRequestStatus(int id, AccountRequestStatus status, int createdBy);
        bool ChangeAccountStatus(int id, int updatedBy);
        IEnumerable<AccountChannelTypeDTO> GetAccountChannelTypes(int accountId);
        AccountChannelTypeDTO EditAccountChannelTypes(AccountChannelTypeDTO accountChannelTypeDTO);
        AccountChannelTypeDTO DeleteAccountChannelTypes(int id);
        AccountChannelTypeDTO AddAccountChannelTypes(AccountChannelTypeDTO accountChannelTypeDTO);
        IEnumerable<AccountChannelDTO> GetChannelsByAccountId(int accountId);
        AccountChannelDTO AddAccountChannel(AccountChannelDTO accountChannelDTO);
        AccountChannelDTO DeleteAccountChannel(int id);
        AccountChannelDTO ChangeAccountChannelStatus(int id,int userUpdated);
    }
}
