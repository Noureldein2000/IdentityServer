using IdentityServer.DTOs;
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
        IEnumerable<AccountTypeProfileDTO> GetAccountTypeProfileLst(int pageNumber, int pageSize);
        IEnumerable<AccountDTO> GetParentAccounts(int id);
        AccountDTO GetParentAccounts(int id, int accountId);
        IEnumerable<AccountTypeProfileDTO> GetProfilesByAccountTypeId(int id);
        IEnumerable<string> GetAccountMappingValidation(int id);
    }
}
