using IdentityServer.DTOs;
using IdentityServer.Helpers;
using IdentityServer.Infrastructure;
using IdentityServer.Models;
using IdentityServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost]
        [Route("Add")]
        public IActionResult Add(AddAccountRequestModel addRequestModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("102", string.Join(", ", ModelState.Values));

                var result = _accountService.Add(new AccountRequestDTO
                {
                    OwnerName = addRequestModel.OwnerName,
                    AccountName = addRequestModel.AccountName,
                    Mobile = addRequestModel.Mobile,
                    Address = addRequestModel.Address,
                    Email = addRequestModel.Email,
                    NationalID = addRequestModel.NationalID,
                    CommercialRegistrationNo = addRequestModel.CommercialRegistrationNo,
                    TaxNo = addRequestModel.TaxNo,
                    ActivityID = addRequestModel.ActivityID,
                });

                return Ok(Map(result));
            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.ErrorCode, ex.Message);
            }
            catch (OkException ex)
            {
                return Ok(ex.ErrorCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("Get/{status}")]
        public IActionResult Get([FromQuery] AccountRequestStatus status = AccountRequestStatus.UnderProcessing)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("102", string.Join(", ", ModelState.Values));

                var result = _accountService.GetAccountRequests(status).Select(ard => Map(ard));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("ChangeStatus/{Id}/{status}")]
        public IActionResult ChangeStatus(int Id, AccountRequestStatus status)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("102", string.Join(", ", ModelState.Values));

                var result = _accountService.ChangeAccountRequestStatus(Id, status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        #region Helper Method
        //Helper Method
        private AccountRequestModel Map(AccountRequestDTO model)
        {
            return new AccountRequestModel
            {
                Id = model.Id,
                OwnerName = model.OwnerName,
                AccountName = model.AccountName,
                Mobile = model.Mobile,
                Address = model.Address,
                Email = model.Email,
                NationalID = model.NationalID,
                CommercialRegistrationNo = model.CommercialRegistrationNo,
                TaxNo = model.TaxNo,
                ActivityID = model.ActivityID,
                ActivityName = model.ActivityName
            };
        }
        #endregion
    }
}
