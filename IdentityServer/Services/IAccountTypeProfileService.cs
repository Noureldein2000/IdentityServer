using IdentityServer.DTOs;
using IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
   public interface IAccountTypeProfileService
    {
        AccountTypeProfileDTO AddAccountTypeProfile (AccountTypeProfileDTO accountTypeProfileDTO);
        ListAccountTypeAndProfileDTO GetLstAccountTypeAndProfile();
        void DeleteAccountTypeProfile(int id);
        PagedResult<AccountTypeProfileDTO> GetAccountTypeProfileLst(int pageNumber, int pageSize);
        IEnumerable<AccountDTO> GetParentAccounts(int id);
        IEnumerable<AccountTypeProfileDTO> GetProfilesByAccountTypeId(int id);
    }
}
