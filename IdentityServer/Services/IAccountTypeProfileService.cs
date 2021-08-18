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
    }
}
