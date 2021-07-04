using IdentityServer.DTOs;
using IdentityServer.Entities;
using IdentityServer.Infrastructure;
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
        private readonly UserManager<ApplicationUser> _userManager;
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

        public AccountRequestDTO Add(AccountRequestDTO accountRequestDto)
        {
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

        public AccountRequestStatus ChangeAccountRequestStatus(int id, AccountRequestStatus status)
        {
            var currentAccountRequest = _accountRequests.GetById(id);
            currentAccountRequest.AccountRequestStatus = status;

            if (status == AccountRequestStatus.Approved)
            {
                Account account = new Account();
                account.Address = currentAccountRequest.Address;
                account.Active = 0;
                account.TaxNo = currentAccountRequest.TaxNo;
                account.CommercialRegistrationNo = currentAccountRequest.CommercialRegistrationNo;
                account.Name = currentAccountRequest.AccountName;

                account.Activity = _activity.GetById(currentAccountRequest.ActivityID).NameAr;
                //account.Activity = currentAccountRequest.Activity.NameAr; //error object null refrence

                //account.CreatedBy = _userManager // we need find current user Id to add it
                account = _account.Add(account);

                _unitOfWork.SaveChanges();

                AccountOwner accountOwner = new AccountOwner();
                accountOwner.Name = currentAccountRequest.OwnerName;
                accountOwner.Address = currentAccountRequest.Address;
                accountOwner.Email = currentAccountRequest.Email;
                accountOwner.Mobile = currentAccountRequest.Mobile;
                accountOwner.NationalID = currentAccountRequest.NationalID;
                accountOwner.AccountID = account.ID;
                _accountOwner.Add(accountOwner);
            }

            _unitOfWork.SaveChanges();
            return status;
        }

        public IEnumerable<AccountRequestDTO> GetAccountRequests(AccountRequestStatus status = AccountRequestStatus.UnderProcessing)
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
                    ActivityName = ar.Activity.NameAr
                }).ToList();

            return accountRequestLst;
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
