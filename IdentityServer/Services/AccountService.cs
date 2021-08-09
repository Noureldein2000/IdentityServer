﻿using IdentityServer.Data.Entities;
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
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IBaseRepository<AccountRequest, int> accountRequests,
            IBaseRepository<Account, int> account,
             IBaseRepository<AccountOwner, int> accountOwner,
            IUnitOfWork unitOfWork)
        {
            _accountRequests = accountRequests;
            _account = account;
            _accountOwner = accountOwner;
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
                }
            });

            _unitOfWork.SaveChanges();
            return MapEntityToDto(account);
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
            });

            _unitOfWork.SaveChanges();
            return MapEntityToDto(entityRequest);
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
                        Address = currentAccountRequest.TaxNo,
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
        #endregion
    }
}
