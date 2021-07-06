using IdentityServer.DTOs;
using IdentityServer.Entities;
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
        private readonly IBaseRepository<AccountOwner, int> _accountOwner;
        private readonly IBaseRepository<Account, int> _account;
        private readonly IBaseRepository<Activity, int> _activity;
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IBaseRepository<AccountRequest, int> accountRequests,
            IBaseRepository<AccountOwner, int> accountOwner,
            IBaseRepository<Account, int> account,
                IBaseRepository<Activity, int> activity,
            IUnitOfWork unitOfWork)
        {
            _accountRequests = accountRequests;
            _accountOwner = accountOwner;
            _account = account;
            _activity = activity;
            _unitOfWork = unitOfWork;
        }

        public AccountRequestDTO AddAccountRequest(AccountRequestDTO accountRequestDto)
        {
            var checkExist = _accountRequests.Any(c => c.Mobile == accountRequestDto.Mobile && c.AccountRequestStatus != AccountRequestStatus.Rejected);
            if(checkExist)
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
        #endregion
    }
}
