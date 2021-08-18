using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Helpers;
using IdentityServer.Infrastructure;
using IdentityServer.Properties;
using IdentityServer.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<AccountRequest, int> _accountRequests;
        private readonly IBaseRepository<Account, int> _account;
        private readonly IBaseRepository<AccountOwner, int> _accountOwner;
        private readonly IBaseRepository<AccountChannelType, int> _accountChannelType;
        private readonly IBaseRepository<AccountChannel, int> _accountChannel;
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IBaseRepository<AccountRequest, int> accountRequests,
            IBaseRepository<Account, int> account,
             IBaseRepository<AccountOwner, int> accountOwner,
             IBaseRepository<AccountChannelType, int> accountChannelType,
             IBaseRepository<AccountChannel, int> accountChannel,
            IUnitOfWork unitOfWork)
        {
            _accountRequests = accountRequests;
            _account = account;
            _accountOwner = accountOwner;
            _accountChannelType = accountChannelType;
            _accountChannel = accountChannel;
            _unitOfWork = unitOfWork;
        }

        public AccountDTO AddAccount(AccountDTO addAccountDTO)
        {
            var checkExist = _accountOwner.Any(c => c.Mobile == addAccountDTO.Mobile || c.NationalID == addAccountDTO.NationalID);
            if (checkExist)
                throw new OkException(Resources.ThisMobileNumberOrNationalIdAlreadyExists, ErrorCodes.ChangePassword.MobileNumberExists);

            var account = _account.Add(new Account
            {
                Address = addAccountDTO.TaxNo,
                TaxNo = addAccountDTO.TaxNo,
                ActivityID = addAccountDTO.ActivityID,
                CommercialRegistrationNo = addAccountDTO.CommercialRegistrationNo,
                Name = addAccountDTO.AccountName,
                Longitude = addAccountDTO.Longitude,
                Latitude = addAccountDTO.Latitude,
                CreatedBy = addAccountDTO.CreatedBy,
                AccountTypeProfileID = addAccountDTO.AccountTypeProfileID,
                RegionID = addAccountDTO.RegionID,
                EntityID = addAccountDTO.EntityID,
                AccountOwner = new AccountOwner
                {
                    Name = addAccountDTO.OwnerName,
                    Address = addAccountDTO.Address,
                    Email = addAccountDTO.Email,
                    Mobile = addAccountDTO.Mobile,
                    NationalID = addAccountDTO.NationalID
                },
                AccountRelationMappings = new List<AccountRelationMapping>
                {
                   new AccountRelationMapping { ParentID=addAccountDTO.ParentID}
                }

            });

            _unitOfWork.SaveChanges();
            return MapEntityToDto(account);
        }

        public AccountChannelDTO AddAccountChannel(AccountChannelDTO accountChannelDTO)
        {
            var checkExists = _accountChannel.Getwhere(ac => ac.AccountID == accountChannelDTO.AccountID && ac.ChannelID == accountChannelDTO.ChannelID).Any();
            if (checkExists) throw new OkException(Resources.ThisAccountHasChannelAlready, ErrorCodes.ChangePassword.MobileNumberExists);

            var addedEntity = _accountChannel.Add(new AccountChannel
            {
                AccountID = accountChannelDTO.AccountID,
                ChannelID = accountChannelDTO.ChannelID,
                Status = accountChannelDTO.Status,
                CreatedBy = accountChannelDTO.CreatedBy
            });
            _unitOfWork.SaveChanges();

            return MapEntityToDto(addedEntity);
        }

        public void AddAccountChannelTypes(AccountChannelTypeDTO accountChannelTypeDTO)
        {
            var checkExists = _accountChannelType.Any(act => act.AccountID == accountChannelTypeDTO.AccountID && act.ChannelTypeID == accountChannelTypeDTO.ChannelTypeID);
            if (checkExists) throw new OkException(Resources.ThisAccountHasChannelTypeBefore, ErrorCodes.ChangePassword.MobileNumberExists);

            _accountChannelType.Add(new AccountChannelType
            {
                AccountID = accountChannelTypeDTO.AccountID,
                ChannelTypeID = accountChannelTypeDTO.ChannelTypeID,
                ExpirationPeriod = accountChannelTypeDTO.ExpirationPeriod,
                HasLimitedAccess = accountChannelTypeDTO.HasLimitedAccess
            });

            _unitOfWork.SaveChanges();
        }

        public AccountRequestDTO AddAccountRequest(AccountRequestDTO accountRequestDto)
        {
            var checkExist = _accountRequests.Any(c => c.Mobile == accountRequestDto.Mobile && c.AccountRequestStatus != AccountRequestStatus.Rejected);
            if (checkExist)
                throw new OkException(Resources.Thismobilenumberalreadyexists, ErrorCodes.ChangePassword.MobileNumberExists);

            var entityRequest = _accountRequests.Add(new AccountRequest
            {
                OwnerName = accountRequestDto.OwnerName,
                AccountName = accountRequestDto.AccountName,
                Mobile = accountRequestDto.Mobile,
                Address = accountRequestDto.Address,
                Email = accountRequestDto.Email,
                NationalID = accountRequestDto.NationalID,
                CommercialRegistrationNo = accountRequestDto.CommercialRegistrationNo,
                TaxNo = accountRequestDto.TaxNo,
                ActivityID = accountRequestDto.ActivityID,
                CreatedBy = accountRequestDto.CreatedBy
            });

            _unitOfWork.SaveChanges();
            return MapEntityToDto(entityRequest);
        }

        public bool ChangeAccountChannelStatus(int id)
        {
            var current = _accountChannel.GetById(id);
            current.Status = !current.Status;
            _unitOfWork.SaveChanges();
            return true;
        }

        public AccountRequestStatus ChangeAccountRequestStatus(int id, AccountRequestStatus status, int createdBy)
        {
            var currentAccountRequest = _accountRequests.GetById(id);

            switch (status)
            {
                case AccountRequestStatus.UnderProcessing:
                    throw new AuthorizationException(Resources.UnavailableStatus, ErrorCodes.Admin.UnavailableStatus);

                case AccountRequestStatus.Approved:
                    currentAccountRequest.AccountRequestStatus = AccountRequestStatus.Approved;
                    _account.Add(new Account
                    {
                        Address = currentAccountRequest.Address,
                        TaxNo = currentAccountRequest.TaxNo,
                        ActivityID = currentAccountRequest.ActivityID,
                        CommercialRegistrationNo = currentAccountRequest.CommercialRegistrationNo,
                        Name = currentAccountRequest.AccountName,
                        CreatedBy = createdBy,
                        AccountOwner = new AccountOwner
                        {
                            Name = currentAccountRequest.OwnerName,
                            Address = currentAccountRequest.Address,
                            Email = currentAccountRequest.Email,
                            Mobile = currentAccountRequest.Mobile,
                            NationalID = currentAccountRequest.NationalID
                        }
                    });
                    break;
                case AccountRequestStatus.Rejected:
                    currentAccountRequest.AccountRequestStatus = AccountRequestStatus.Rejected;
                    break;
                default:
                    throw new AuthorizationException(Resources.UnavailableStatus, ErrorCodes.Admin.UnavailableStatus);
            }

            _unitOfWork.SaveChanges();
            return status;
        }

        public bool ChangeAccountStatus(int id, int updatedBy)
        {
            var currentAccount = _account.GetById(id);

            currentAccount.Active = !currentAccount.Active;
            currentAccount.UpdateBy = updatedBy;

            _unitOfWork.SaveChanges();
            return currentAccount.Active;
        }

        public void DeleteAccountChannel(int id)
        {
            _accountChannel.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public void DeleteAccountChannelTypes(int id)
        {
            var result = _accountChannelType.Delete(id);
            _unitOfWork.SaveChanges();

        }

        public AccountDTO EditAccount(AccountDTO editAccountDTO)
        {
            var checkAccountExist = _account.Any(c => c.ID == editAccountDTO.Id);
            if (!checkAccountExist)
                throw new OkException(Resources.ThisAccountIsNotExists, ErrorCodes.ChangePassword.MobileNumberExists);

            var account = _account.Getwhere(a => a.ID == editAccountDTO.Id).Include(a => a.AccountOwner).FirstOrDefault();

            account.Address = editAccountDTO.Address;
            account.TaxNo = editAccountDTO.TaxNo;
            account.ActivityID = editAccountDTO.ActivityID;
            account.CommercialRegistrationNo = editAccountDTO.CommercialRegistrationNo;
            account.Name = editAccountDTO.AccountName;
            account.Longitude = editAccountDTO.Longitude;
            account.Latitude = editAccountDTO.Latitude;
            account.UpdateBy = editAccountDTO.UpdatedBy;
            account.AccountTypeProfileID = editAccountDTO.AccountTypeProfileID;
            account.RegionID = editAccountDTO.RegionID;
            account.EntityID = editAccountDTO.EntityID;

            account.AccountOwner.Name = editAccountDTO.OwnerName;
            account.AccountOwner.Address = editAccountDTO.Address;
            account.AccountOwner.Email = editAccountDTO.Email;
            account.AccountOwner.Mobile = editAccountDTO.Mobile;
            account.AccountOwner.NationalID = editAccountDTO.NationalID;

            _unitOfWork.SaveChanges();
            return MapEntityToDto(account);
        }

        public AccountChannelTypeDTO EditAccountChannelTypes(AccountChannelTypeDTO accountChannelTypeDTO)
        {
            var current = _accountChannelType.Getwhere(act => act.ID == accountChannelTypeDTO.Id).FirstOrDefault();
            current.HasLimitedAccess = accountChannelTypeDTO.HasLimitedAccess;
            current.ExpirationPeriod = accountChannelTypeDTO.ExpirationPeriod;

            _unitOfWork.SaveChanges();
            return MapEntityToDto(current);
        }

        public AccountDTO GetAccountById(int id)
        {
            return _account.Getwhere(x => x.ID == id).Include(a => a.AccountOwner).AsNoTracking()
               .Select(ar => new AccountDTO
               {
                   Id = ar.ID,
                   OwnerName = ar.AccountOwner.Name,
                   AccountName = ar.Name,
                   Mobile = ar.AccountOwner.Mobile,
                   Address = ar.AccountOwner.Address,
                   Email = ar.AccountOwner.Email,
                   NationalID = ar.AccountOwner.NationalID,
                   CommercialRegistrationNo = ar.CommercialRegistrationNo,
                   TaxNo = ar.TaxNo,
                   Longitude = ar.Longitude,
                   Latitude = ar.Latitude,
                   ActivityID = (int)ar.ActivityID,
                   ActivityName = ar.Activity.NameAr,
                   RegionID = ar.RegionID,
                   AccountTypeProfileID = ar.AccountTypeProfileID,
                   EntityID = ar.EntityID
               }).FirstOrDefault();
        }

        public IEnumerable<AccountChannelTypeDTO> GetAccountChannelTypes(int accountId)
        {
            return _accountChannelType.Getwhere(act => act.AccountID == accountId).Select(act => new AccountChannelTypeDTO
            {
                Id = act.ID,
                AccountID = act.AccountID,
                ChannelTypeID = act.ChannelTypeID,
                ChannelTypeName = act.ChannelType.Name,
                ExpirationPeriod = act.ExpirationPeriod,
                HasLimitedAccess = act.HasLimitedAccess
            }).ToList();
        }

        public IEnumerable<AccountRequestDTO> GetAccountRequests(AccountRequestStatus status, int pageNumber, int pageSize)
        {
            var accountRequestLst = _accountRequests.Getwhere(x => x.AccountRequestStatus == status).AsNoTracking()
                .Select(ar => new AccountRequestDTO
                {
                    Id = ar.ID,
                    OwnerName = ar.OwnerName,
                    AccountName = ar.AccountName,
                    Mobile = ar.Mobile,
                    Address = ar.Address,
                    Email = ar.Email,
                    NationalID = ar.NationalID,
                    CommercialRegistrationNo = ar.CommercialRegistrationNo,
                    TaxNo = ar.TaxNo,
                    ActivityID = ar.ActivityID,
                    ActivityName = ar.Activity.NameAr,
                    CreationDate = ar.CreationDate
                }).OrderBy(ar => ar.CreationDate).Skip(pageNumber - 1).Take(pageSize).ToList();
            return accountRequestLst;
        }

        public AccountRequestDTO GetAccountRequestsById(int id)
        {
            return _accountRequests.Getwhere(x => x.ID == id).AsNoTracking()
                .Select(ar => new AccountRequestDTO
                {
                    Id = ar.ID,
                    OwnerName = ar.OwnerName,
                    AccountName = ar.AccountName,
                    Mobile = ar.Mobile,
                    Address = ar.Address,
                    Email = ar.Email,
                    NationalID = ar.NationalID,
                    CommercialRegistrationNo = ar.CommercialRegistrationNo,
                    TaxNo = ar.TaxNo,
                    ActivityID = ar.ActivityID,
                    ActivityName = ar.Activity.NameAr
                }).FirstOrDefault();
        }

        public IEnumerable<AccountDTO> GetAccounts(int pageNumber, int pageSize)
        {
            var accountLst = _account.Getwhere(a => true).Select(ar => new AccountDTO
            {
                Id = ar.ID,
                OwnerName = ar.AccountOwner.Name,
                AccountName = ar.Name,
                Mobile = ar.AccountOwner.Mobile,
                Address = ar.Address,
                Email = ar.AccountOwner.Email,
                NationalID = ar.AccountOwner.NationalID,
                CommercialRegistrationNo = ar.CommercialRegistrationNo,
                TaxNo = ar.TaxNo,
                ActivityID = (int)ar.ActivityID,
                ActivityName = ar.Activity.NameAr,
                CreationDate = ar.CreationDate
            }).OrderByDescending(ar => ar.CreationDate).Skip(pageNumber - 1).Take(pageSize).AsNoTracking().ToList();
            return accountLst;
        }

        public IEnumerable<AccountChannelDTO> GetChannelsByAccountId(int accountId)
        {
            return _accountChannel.Getwhere(ac => ac.AccountID == accountId && ac.Status == true).Select(ac => new AccountChannelDTO
            {
                Id = ac.ID,
                AccountID = ac.AccountID,
                ChannelID = ac.ChannelID,
                Status = ac.Status,
                CreatedBy = ac.CreatedBy,
                UpdatedBy = ac.UpdatedBy
            }).ToList();
        }


        #region Helper Method
        //Helper Method

        private AccountRequestDTO MapEntityToDto(AccountRequest entityRequest) => new AccountRequestDTO
        {
            Id = entityRequest.ID,
            OwnerName = entityRequest.OwnerName,
            AccountName = entityRequest.AccountName,
            Mobile = entityRequest.Mobile,
            Address = entityRequest.Address,
            Email = entityRequest.Email,
            NationalID = entityRequest.NationalID,
            CommercialRegistrationNo = entityRequest.CommercialRegistrationNo,
            TaxNo = entityRequest.TaxNo,
            ActivityID = entityRequest.ActivityID,
        };

        private AccountDTO MapEntityToDto(Account entityRequest) => new AccountDTO
        {
            Id = entityRequest.ID,
            Address = entityRequest.Address,
            CommercialRegistrationNo = entityRequest.CommercialRegistrationNo,
            TaxNo = entityRequest.TaxNo,
            OwnerName = entityRequest.AccountOwner.Name,
            AccountName = entityRequest.Name,
            Mobile = entityRequest.AccountOwner.Mobile,
            NationalID = entityRequest.AccountOwner.NationalID,
            Email = entityRequest.AccountOwner.Email,
            ActivityID = (int)entityRequest.ActivityID
            //ActivityName=entityRequest.Activity.Name
        };

        private AccountChannelTypeDTO MapEntityToDto(AccountChannelType entityRequest) => new AccountChannelTypeDTO
        {
            Id = entityRequest.ID,
            AccountID = entityRequest.AccountID,
            ChannelTypeID = entityRequest.ChannelTypeID,
            ExpirationPeriod = entityRequest.ExpirationPeriod,
            HasLimitedAccess = entityRequest.HasLimitedAccess
        };

        private AccountChannelDTO MapEntityToDto(AccountChannel entityRequest) => new AccountChannelDTO
        {
            Id = entityRequest.ID,
            AccountID = entityRequest.AccountID,
            ChannelID = entityRequest.ChannelID,
            Status = entityRequest.Status,
            CreatedBy = entityRequest.CreatedBy
        };
        #endregion
    }
}
