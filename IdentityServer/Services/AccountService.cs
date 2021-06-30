using IdentityServer.DTOs;
using IdentityServer.Entities;
using IdentityServer.Infrastructure;
using IdentityServer.Repositories.Base;
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
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IBaseRepository<AccountRequest, int> accountRequests,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _accountRequests = accountRequests;
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

        public AccountRequestStatus ChangeAccountRequestStatus(AccountRequestStatus status, int id)
        {
            throw new NotImplementedException();
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
