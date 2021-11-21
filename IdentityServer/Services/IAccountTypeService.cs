using IdentityServer.DTOs;
using IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface IAccountTypeService
    {
        void AddAccountType(AccountTypeDTO accountTypeDTO);
        void DeleteAccountType(int id);
        void ChnageStatus(int id);
        AccountTypeDTO GetAccountTypeById(int id);
        void EditAccountType(AccountTypeDTO accountTypeDTO);
        PagedResult<AccountTypeDTO> GetAccountTypes(int pageNumber, int pageSize, string language);
    }
}
