using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Helpers;
using IdentityServer.Infrastructure;
using IdentityServer.Properties;
using IdentityServer.Repositories.Base;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class AccountTypeProfileService : IAccountTypeProfileService
    {
        private readonly IBaseRepository<AccountTypeProfile, int> _accountTypeProfile;
        private readonly IBaseRepository<AccountType, int> _accountType;
        private readonly IBaseRepository<Profile, int> _profile;
        private readonly IBaseRepository<AccountMappingValidation, int> _accountMappingValidation;
        private readonly IBaseRepository<Account, int> _account;
        private readonly IStringLocalizer<AuthenticationResource> _localizer;
        private readonly IUnitOfWork _unitOfWork;
        public AccountTypeProfileService(
            IBaseRepository<AccountTypeProfile, int> accountTypeProfile,
            IBaseRepository<AccountType, int> accountType,
            IBaseRepository<Profile, int> profile,
            IBaseRepository<AccountMappingValidation, int> accountMappingValidation,
           IBaseRepository<Account, int> account,
           IStringLocalizer<AuthenticationResource> localizer,
        IUnitOfWork unitOfWork)
        {
            _accountTypeProfile = accountTypeProfile;
            _accountType = accountType;
            _profile = profile;
            _accountMappingValidation = accountMappingValidation;
            _account = account;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
        }
        public AccountTypeProfileDTO AddAccountTypeProfile(AccountTypeProfileDTO accountTypeProfileDTO)
        {
            var checkExists = _accountTypeProfile.Getwhere(atp => atp.AccountTypeID == accountTypeProfileDTO.AccountTypeID && atp.ProfileID == accountTypeProfileDTO.ProfileID).Any();
            if (checkExists) throw new OkException(_localizer["ThisAccountIsNotExists"].Value, ErrorCodes.ChangePassword.InvalidPassword);

            var addedEntity = _accountTypeProfile.Add(new AccountTypeProfile
            {
                AccountTypeID = accountTypeProfileDTO.AccountTypeID,
                ProfileID = accountTypeProfileDTO.ProfileID
            });

            _unitOfWork.SaveChanges();

            return MapEntityToDto(addedEntity);
        }
        public void DeleteAccountTypeProfile(int id)
        {
            _accountTypeProfile.Delete(id);
            _unitOfWork.SaveChanges();
        }
        public IEnumerable<AccountTypeProfileDTO> GetAccountTypeProfileLst(int pageNumber, int pageSize)
        {
            var results = _accountTypeProfile.Getwhere(atp => true).Select(atp => new AccountTypeProfileDTO
            {
                Id = atp.ID,
                AccountTypeID = atp.AccountTypeID,
                ProfileID = atp.ProfileID,
                FullName = atp.AccountType.Name + " - " + atp.Profile.Name
            }).OrderBy(c => c.FullName).Skip(pageNumber - 1).Take(pageSize).ToList();

            return results;
        }
        public ListAccountTypeAndProfileDTO GetLstAccountTypeAndProfile()
        {
            var accountTypeLst = _accountType.Getwhere(at => at.Status == true).Select(at => new AccountTypeDTO
            {
                Id = at.ID,
                Name = at.Name,
                Status = at.Status
            }).ToList();

            var profileLst = _profile.GetAll().Select(p => new ProfileDTO
            {
                Id = p.ID,
                Name = p.Name
            }).ToList();

            return new ListAccountTypeAndProfileDTO()
            {
                LstAccountType = accountTypeLst,
                LstProfile = profileLst
            };
        }

        public IEnumerable<AccountDTO> GetParentAccounts(int id)
        {
            var accountTypeId = _accountTypeProfile.GetById(id).AccountTypeID;

            var parentTypeIds = _accountMappingValidation.Getwhere(amv => amv.ChildID == accountTypeId)
                .Select(x => x.ParentID).ToList();

            var accounts = _accountTypeProfile.Getwhere(atp => parentTypeIds.Contains(atp.AccountTypeID))
                .SelectMany(atp => atp.Accounts).ToList();

            return accounts.Select(a => new AccountDTO()
            {
                Id = a.ID,
                AccountName = a.ID + " - " + a.Name,
            }).ToList();

            //return _account.Getwhere(a => a.prof).Select().ToList();
        }
        public AccountDTO GetParentAccounts(int id, int accountId)
        {
            var accountTypeId = _accountTypeProfile.GetById(id).AccountTypeID;

            var parentTypeIds = _accountMappingValidation.Getwhere(amv => amv.ChildID == accountTypeId)
                .Select(x => x.ParentID).ToList();

            var parentTypeProfileIds = _accountTypeProfile.Getwhere(p => parentTypeIds.Contains(p.AccountTypeID))
                .Select(x => x.ID).ToList();

            return _account.Getwhere(a => parentTypeIds.Contains(a.AccountTypeProfile.AccountTypeID) & a.ID == accountId && parentTypeProfileIds.Contains((int)a.AccountTypeProfileID))
                .Select(a => new AccountDTO
                {
                    AccountName = a.Name,
                }).FirstOrDefault();
        }
        public IEnumerable<string> GetAccountMappingValidation(int id)
        {
            var parentTypeIds = _accountMappingValidation.Getwhere(amv => amv.ChildID == id)
                .Select(x => x.ParentID).ToList();

            return _accountType.Getwhere(a => parentTypeIds.Contains(a.ID)).Select(a => a.NameAr).ToList();
        }
        public IEnumerable<AccountTypeProfileDTO> GetProfilesByAccountTypeId(int id)
        {
            return _accountTypeProfile.Getwhere(atp => atp.AccountTypeID == id).Select(atp => new AccountTypeProfileDTO
            {
                Id = atp.ID,
                AccountTypeID = atp.AccountTypeID,
                ProfileID = atp.ProfileID,
                FullName = atp.AccountType.Name + " - " + atp.Profile.Name,
                ProfileName = atp.Profile.Name

            }).ToList();
        }

        #region Helper Method
        //Helper Method
        private AccountTypeProfileDTO MapEntityToDto(AccountTypeProfile entityRequest) => new AccountTypeProfileDTO
        {
            Id = entityRequest.ID,
            AccountTypeID = entityRequest.AccountTypeID,
            ProfileID = entityRequest.ProfileID
        };
        #endregion
    }
}
