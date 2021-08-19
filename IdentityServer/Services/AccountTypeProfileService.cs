using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Helpers;
using IdentityServer.Infrastructure;
using IdentityServer.Properties;
using IdentityServer.Repositories.Base;
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
        private readonly IUnitOfWork _unitOfWork;
        public AccountTypeProfileService(
            IBaseRepository<AccountTypeProfile, int> accountTypeProfile,
            IBaseRepository<AccountType, int> accountType,
            IBaseRepository<Profile, int> profile,
            IUnitOfWork unitOfWork)
        {
            _accountTypeProfile = accountTypeProfile;
            _accountType = accountType;
            _profile = profile;
            _unitOfWork = unitOfWork;
        }
        public AccountTypeProfileDTO AddAccountTypeProfile(AccountTypeProfileDTO accountTypeProfileDTO)
        {
            var checkExists = _accountTypeProfile.Getwhere(atp => atp.AccountTypeID == accountTypeProfileDTO.AccountTypeID && atp.ProfileID == accountTypeProfileDTO.ProfileID).Any();
            if (checkExists) throw new OkException(Resources.ThisAccountIsNotExists, ErrorCodes.ChangePassword.InvalidPassword);

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
                FullName = atp.AccountType.Name +" - " + atp.Profile.Name
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
