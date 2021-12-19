using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Models;
using IdentityServer.Repositories.Base;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IBaseRepository<AccountType, int> _accountType;
        private readonly IStringLocalizer<AuthenticationResource> _localizer;
        private readonly IUnitOfWork _unitOfWork;
        public AccountTypeService(IBaseRepository<AccountType, int> accountType,
             IStringLocalizer<AuthenticationResource> localizer,
        IUnitOfWork unitOfWork)
        {
            _accountType = accountType;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
        }

        public void AddAccountType(AccountTypeDTO accountTypeDTO)
        {
            _accountType.Add(new AccountType
            {
                Name = accountTypeDTO.Name,
                NameAr = accountTypeDTO.NameAr,
                Status = accountTypeDTO.Status,
                TreeLevel = accountTypeDTO.TreeLevel
            });

            _unitOfWork.SaveChanges();
        }

        public void ChnageStatus(int id)
        {
            var current = _accountType.GetById(id);
            current.Status = !current.Status;
            _unitOfWork.SaveChanges();
        }

        public void DeleteAccountType(int id)
        {
            _accountType.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public void EditAccountType(AccountTypeDTO accountTypeDTO)
        {
            var current = _accountType.GetById(accountTypeDTO.Id);
            current.Name = accountTypeDTO.Name;
            current.NameAr = accountTypeDTO.NameAr;
            _unitOfWork.SaveChanges();
        }

        public AccountTypeDTO GetAccountTypeById(int id)
        {
            return _accountType.Getwhere(x => x.ID == id).Select(x => new AccountTypeDTO()
            {
                Id = x.ID,
                Name = x.Name,
                NameAr = x.NameAr
            }).FirstOrDefault();
        }

        public PagedResult<AccountTypeDTO> GetAccountTypes(int pageNumber, int pageSize, string language)
        {
            var accountTypes = _accountType.GetAll().Select(atp => new
            {
                Id = atp.ID,
                Name = atp.Name,
                NameAr = atp.NameAr,
                Status = atp.Status,
                CreationDate = atp.CreationDate
            });

            var count = accountTypes.Count();

            var resultList = accountTypes.OrderByDescending(ar => ar.CreationDate)
          .Skip((pageNumber * pageSize) - pageSize).Take(pageSize)
          .ToList();

            return new PagedResult<AccountTypeDTO>
            {
                Results = resultList.Select(atp => new AccountTypeDTO
                {
                    Id = atp.Id,
                    Name = atp.Name,
                    NameAr = atp.NameAr,
                    Status = atp.Status
                }).ToList(),
                PageCount = count
            };
        }
    }
}
