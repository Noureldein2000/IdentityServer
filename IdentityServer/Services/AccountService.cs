﻿using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Helpers;
using IdentityServer.Infrastructure;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<AuthenticationResource> _localizer;
        public AccountService(IBaseRepository<AccountRequest, int> accountRequests,
            IBaseRepository<Account, int> account,
            IUnitOfWork unitOfWork,
            IStringLocalizer<AuthenticationResource> localizer)
        {
            _accountRequests = accountRequests;
            _account = account;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public AccountRequestDTO AddAccountRequest(AccountRequestDTO accountRequestDto)
        {
            var checkExist = _accountRequests.Any(c => c.Mobile == accountRequestDto.Mobile && c.AccountRequestStatus != AccountRequestStatus.Rejected);
            if(checkExist)
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
                    throw new AuthorizationException(_localizer["UnavailableStatus"].Value, ErrorCodes.Admin.UnavailableStatus);

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
                    throw new AuthorizationException(_localizer["UnavailableStatus"].Value, ErrorCodes.Admin.UnavailableStatus);
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
        #endregion
    }
}
