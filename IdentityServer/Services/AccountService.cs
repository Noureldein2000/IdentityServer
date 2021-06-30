using IdentityServer.DTOs;
using IdentityServer.Entities;
using IdentityServer.Repositories.Base;
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

        public AddRequestDTO AddRequest(AddRequestDTO accountRequestDto)
        {
          var entityRequest=  _accountRequests.Add(new AccountRequest
            {
                ID = accountRequestDto.Id,
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


    #region Helper Method
    //Helper Method
    private AccountRequest MapDtoToEntity(AddRequestDTO addRequestDTO) => new AccountRequest
    {
        ID = addRequestDTO.Id,
        OwnerName = addRequestDTO.OwnerName,
        AccountName = addRequestDTO.AccountName,
        Mobile = addRequestDTO.Mobile,
        Address = addRequestDTO.Address,
        Email = addRequestDTO.Email,
        NationalID = addRequestDTO.NationalID,
        CommercialRegistrationNo = addRequestDTO.CommercialRegistrationNo,
        TaxNo = addRequestDTO.TaxNo,
        ActivityID = addRequestDTO.ActivityID,
    };

        private AddRequestDTO MapEntityToDto(AccountRequest entityRequest) => new AddRequestDTO
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
