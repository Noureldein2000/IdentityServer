using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Helpers;
using IdentityServer.Infrastructure;
using IdentityServer.Models;
using IdentityServer.Properties;
using IdentityServer.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
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
        private readonly IBaseRepository<AccountChannelHistory, int> _accountChannelHistory;
        private readonly IBaseRepository<AccountRelationMapping, int> _accountRelationMapping;
        private readonly IStringLocalizer<AuthenticationResource> _localizer;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IBaseRepository<AccountRequest, int> accountRequests,
            IBaseRepository<Account, int> account,
             IBaseRepository<AccountOwner, int> accountOwner,
             IBaseRepository<AccountChannelType, int> accountChannelType,
             IBaseRepository<AccountChannel, int> accountChannel,
             IBaseRepository<AccountChannelHistory, int> accountChannelHistory,
        IStringLocalizer<AuthenticationResource> localizer,
             UserManager<ApplicationUser> userManager,
             IBaseRepository<AccountRelationMapping, int> accountRelationMapping,
            IUnitOfWork unitOfWork)
        {
            _accountRequests = accountRequests;
            _account = account;
            _accountOwner = accountOwner;
            _accountChannelType = accountChannelType;
            _accountChannel = accountChannel;
            _accountChannelHistory = accountChannelHistory;
            _userManager = userManager;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
            _accountRelationMapping = accountRelationMapping;
        }

        public AccountDTO AddAccount(AccountDTO addAccountDTO)
        {
            var checkExist = _accountOwner.Any(c => c.Mobile == addAccountDTO.Mobile || c.NationalID == addAccountDTO.NationalID);
            if (checkExist)
                throw new OkException(_localizer["ThisMobileNumberOrNationalIdAlreadyExist"].Value, ErrorCodes.ChangePassword.MobileNumberExists);

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
            if (checkExists) throw new OkException(_localizer["ThisAccountHasChannelAlready"].Value, ErrorCodes.ChangePassword.MobileNumberExists);

            var current = _accountChannel.Getwhere(ac => ac.ChannelID == accountChannelDTO.ChannelID).FirstOrDefault();
            if (current != null)
            {
                AddAccountChannelHistory(current.AccountID, current.ChannelID, current.Status, accountChannelDTO.Reason, accountChannelDTO.CreatedBy);
                DeleteAccountChannel(current.ID);
            }

            var addedEntity = _accountChannel.Add(new AccountChannel
            {
                AccountID = accountChannelDTO.AccountID,
                ChannelID = accountChannelDTO.ChannelID,
                Status = AccountChannelStatus.Inactive,
                CreatedBy = accountChannelDTO.CreatedBy
            });
            _unitOfWork.SaveChanges();

            return MapEntityToDto(addedEntity);
        }

        public AccountChannelTypeDTO AddAccountChannelTypes(AccountChannelTypeDTO accountChannelTypeDTO)
        {
            var checkExists = _accountChannelType.Any(act => act.AccountID == accountChannelTypeDTO.AccountID && act.ChannelTypeID == accountChannelTypeDTO.ChannelTypeID);
            if (checkExists) throw new OkException(_localizer["ThisAccountHasChannelTypeBefore"].Value, ErrorCodes.ChangePassword.MobileNumberExists);

            var addedentity = _accountChannelType.Add(new AccountChannelType
            {
                AccountID = accountChannelTypeDTO.AccountID,
                ChannelTypeID = accountChannelTypeDTO.ChannelTypeID,
                ExpirationPeriod = accountChannelTypeDTO.ExpirationPeriod,
                HasLimitedAccess = accountChannelTypeDTO.HasLimitedAccess
            });

            _unitOfWork.SaveChanges();

            return (MapEntityToDto(addedentity));
        }

        public AccountRequestDTO AddAccountRequest(AccountRequestDTO accountRequestDto)
        {
            var checkExist = _accountRequests.Any(c => c.Mobile == accountRequestDto.Mobile && c.AccountRequestStatus != AccountRequestStatus.Rejected);
            if (checkExist)
                throw new OkException(_localizer["Thismobilenumberalreadyexists"].Value, ErrorCodes.ChangePassword.MobileNumberExists);

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

        public AccountChannelDTO ChangeAccountChannelStatus(int id, AccountChannelStatus status, string reason, int userUpdated)
        {
            var current = _accountChannel.GetById(id);
            AddAccountChannelHistory(current.AccountID, current.ChannelID, current.Status, reason, userUpdated);

            current.Status = status;
            current.UpdatedBy = userUpdated;

            _unitOfWork.SaveChanges();
            return MapEntityToDto(current);
        }

        public AccountRequestStatus ChangeAccountRequestStatus(int id, AccountRequestStatus status, int createdBy)
        {
            var currentAccountRequest = _accountRequests.GetById(id);

            switch (status)
            {
                case AccountRequestStatus.UnderProcessing:
                    throw new AuthorizationException(_localizer["UnavailableStatus"].Value, ErrorCodes.Admin.UnavailableStatus);

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
                    throw new AuthorizationException(_localizer["UnavailableStatus"].Value, ErrorCodes.Admin.UnavailableStatus);
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

        public AccountChannelDTO DeleteAccountChannel(int id)
        {
            var deletedEntity = _accountChannel.Delete(id);
            _unitOfWork.SaveChanges();
            return MapEntityToDto(deletedEntity);
        }

        public AccountChannelTypeDTO DeleteAccountChannelTypes(int id)
        {
            var result = _accountChannelType.Delete(id);
            _unitOfWork.SaveChanges();
            return MapEntityToDto(result);

        }

        public AccountDTO EditAccount(AccountDTO editAccountDTO)
        {
            var checkAccountExist = _account.Any(c => c.ID == editAccountDTO.Id);
            if (!checkAccountExist)
                throw new OkException(_localizer["ThisAccountIsNotExists"].Value, ErrorCodes.ChangePassword.MobileNumberExists);

            var account = _account.Getwhere(a => a.ID == editAccountDTO.Id).Include(a => a.AccountOwner).FirstOrDefault();
            var accountRelationMapping = _accountRelationMapping.Getwhere(a => a.AccountID == editAccountDTO.Id).ToList();
            foreach (var accountRealtion in accountRelationMapping)
            {
                _accountRelationMapping.Delete(accountRealtion.ID);
            }

            //_unitOfWork.SaveChanges();
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

            account.AccountRelationMappings.Add(
                new AccountRelationMapping { AccountID = account.ID, ParentID = editAccountDTO.ParentID });


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
            return _account.Getwhere(x => x.ID == id)
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
                   EntityID = ar.EntityID,
                   GovernerateID = ar.Region.GovernorateID,
                   ParentID = ar.AccountRelationMappings.Select(s => s.ParentID).FirstOrDefault()
               }).FirstOrDefault();
        }

        public AccountChannelTypeDTO GetAccountChannelTypeById(int id)
        {
            return MapEntityToDto(_accountChannelType.GetById(id));
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
            var accountRequestLst = _accountRequests.Getwhere(x => x.AccountRequestStatus == status)
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
            return _accountRequests.Getwhere(x => x.ID == id)
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

        public PagedResult<AccountDTO> GetAccounts(int pageNumber, int pageSize)
        {
            var accountLst = _account.Getwhere(a => true)
                .Select(ar => new
                {
                    Id = ar.ID,
                    OwnerName = ar.AccountOwner.Name,
                    AccountName = ar.Name,
                    ar.AccountOwner.Mobile,
                    ar.Address,
                    ar.AccountOwner.Email,
                    ar.AccountOwner.NationalID,
                    ar.CommercialRegistrationNo,
                    ar.TaxNo,
                    ActivityID = (int)ar.ActivityID,
                    ActivityName = ar.Activity.Name,
                    ar.CreationDate,
                    ar.Active
                });
            var count = accountLst.Count();

            var resultList = accountLst.OrderByDescending(ar => ar.CreationDate)
            .Skip(pageNumber - 1).Take(pageSize)
            .ToList();


            //return accountLst;
            return new PagedResult<AccountDTO>
            {
                Results = resultList.Select(ar => new AccountDTO
                {
                    Id = ar.Id,
                    OwnerName = ar.OwnerName,
                    AccountName = ar.AccountName,
                    Mobile = ar.Mobile,
                    Address = ar.Address,
                    Email = ar.Email,
                    NationalID = ar.NationalID,
                    CommercialRegistrationNo = ar.CommercialRegistrationNo,
                    TaxNo = ar.TaxNo,
                    ActivityID = ar.ActivityID,
                    ActivityName = ar.ActivityName,
                    CreationDate = ar.CreationDate,
                    Status = ar.Active
                }).ToList(),
                PageCount = count
            };
        }

        public IEnumerable<AccountChannelDTO> GetChannelsByAccountId(int accountId)
        {
            var result = _accountChannel.Getwhere(ac => ac.AccountID == accountId).Select(ac => new AccountChannelDTO
            {
                Id = ac.ID,
                AccountID = ac.AccountID,
                ChannelID = ac.ChannelID,
                ChannelName = ac.Channel.Name,
                Serial = ac.Channel.Serial,
                Status = ac.Status,
                CreatedBy = ac.CreatedBy,
                CreatedName = _userManager.Users.Where(u => u.UserId == ac.CreatedBy).FirstOrDefault().Name,
                UpdatedBy = ac.UpdatedBy
            }).ToList();

            return result;
        }

        public PagedResult<AccountDTO> GetAccountsBySearchKey(int? accountType, string searchKey, int pageNumber, int pageSize)
        {
            var accountQuery = _account.Getwhere(a => true);
            var isSearchIdValid = int.TryParse(searchKey, out var searchId);

            if (accountType.HasValue)
            {
                accountQuery = accountQuery.Where(a => a.AccountTypeProfile.AccountTypeID == accountType);
            }
            if (!string.IsNullOrEmpty(searchKey))
            {
                accountQuery = accountQuery.Where(a => isSearchIdValid ? a.ID == searchId : a.Name.Contains(searchKey));
            }

            var count = accountQuery.Count();


            var quey = accountQuery.Include(a => a.AccountOwner).Select(ar => new AccountDTO
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
                ActivityID = ar.ActivityID,
                ActivityName = ar.Activity.Name,
                CreationDate = ar.CreationDate,
                Status = ar.Active
            });


            var resultList = quey.OrderByDescending(ar => ar.CreationDate)
            .Skip(pageNumber - 1).Take(pageSize)
            .ToList();


            //return accountLst;
            return new PagedResult<AccountDTO>
            {
                Results = resultList,
                PageCount = count
            };
        }


        #region Helper Method
        //Helper Method
        private void AddAccountChannelHistory(int accountId, int channelId, AccountChannelStatus status, string reason, int createdBy)
        {
            _accountChannelHistory.Add(new AccountChannelHistory
            {
                AccountID = accountId,
                ChannelID = channelId,
                Status = status,
                Reason = reason,
                CreatedBy = createdBy
            });
        }
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
