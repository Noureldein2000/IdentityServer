using IdentityServer.DTOs;
using IdentityServer.Helpers;
using IdentityServer.Infrastructure;
using IdentityServer.Models;
using IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("AddAccountRequest")]
        [Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        public IActionResult AddAccountRequest([FromBody] AddAccountRequestModel addRequestModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("102", string.Join(", ", ModelState.Values));

                var result = _accountService.AddAccountRequest(new AccountRequestDTO
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
                    CreatedBy = UserIdentityId
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

        [HttpPost]
        [Route("AddAccount")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        public IActionResult AddAccount([FromBody] AddAccountModel addAccountModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("102", string.Join(", ", ModelState.Values));

                var result = _accountService.AddAccount(new AccountDTO
                {
                    OwnerName = addAccountModel.OwnerName,
                    AccountName = addAccountModel.AccountName,
                    Mobile = addAccountModel.Mobile,
                    Address = addAccountModel.Address,
                    Latitude = addAccountModel.Latitude,
                    Longitude = addAccountModel.Longitude,
                    Email = addAccountModel.Email,
                    NationalID = addAccountModel.NationalID,
                    CommercialRegistrationNo = addAccountModel.CommercialRegistrationNo,
                    TaxNo = addAccountModel.TaxNo,
                    ActivityID = addAccountModel.ActivityID,
                    CreatedBy = UserIdentityId,
                    AccountTypeProfileID = addAccountModel.AccountTypeProfileID,
                    RegionID = addAccountModel.RegionID,
                    EntityID = addAccountModel.EntityID
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

        [HttpPut]
        [Route("EditAccount")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        public IActionResult EditAccount([FromBody] EditAccountModel editAccountModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("102", string.Join(", ", ModelState.Values));

                var result = _accountService.EditAccount(new AccountDTO
                {
                    Id=editAccountModel.Id,
                    OwnerName = editAccountModel.OwnerName,
                    AccountName = editAccountModel.AccountName,
                    Mobile = editAccountModel.Mobile,
                    Address = editAccountModel.Address,
                    Latitude = editAccountModel.Latitude,
                    Longitude = editAccountModel.Longitude,
                    Email = editAccountModel.Email,
                    NationalID = editAccountModel.NationalID,
                    CommercialRegistrationNo = editAccountModel.CommercialRegistrationNo,
                    TaxNo = editAccountModel.TaxNo,
                    ActivityID = editAccountModel.ActivityID,
                    UpdatedBy = UserIdentityId,
                    AccountTypeProfileID = editAccountModel.AccountTypeProfileID,
                    RegionID = editAccountModel.RegionID,
                    EntityID = editAccountModel.EntityID
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
        [Route("GetAccountRequestById/{id}")]
        [Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        public IActionResult GetAccountRequestById([FromRoute] int id)
        {
            try
            {
                var result = _accountService.GetAccountRequestsById(id);
                return Ok(Map(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetAccountById/{id}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        public IActionResult GetAccountById(int id)
        {
            try
            {
                var result = _accountService.GetAccountById(id);
                return Ok(Map(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("GetAccountRequestByStatus/{status}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        public IActionResult GetAccountRequestByStatus([FromRoute] AccountRequestStatus status = AccountRequestStatus.UnderProcessing, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var result = _accountService.GetAccountRequests(status, pageNumber, pageSize).Select(ard => Map(ard));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetAccounts")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        public IActionResult GetAccounts(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var result = _accountService.GetAccounts(pageNumber, pageSize).Select(ard => Map(ard));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("ChangeAccountRequestStatus/{Id}/{status}")]
        [Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        public IActionResult ChangeAccountRequestStatus([FromRoute] int Id, AccountRequestStatus status)
        {
            try
            {
                var result = _accountService.ChangeAccountRequestStatus(Id, status, UserIdentityId);
                return Ok(result);
            }
            catch (AuthorizationException ex)
            {
                return BadRequest(ex.ErrorCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ChangeAccountStatus/{Id}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        public IActionResult ChangeAccountStatus([FromRoute] int Id)
        {
            try
            {
                var result = _accountService.ChangeAccountStatus(Id, UserIdentityId);
                return Ok(result);
            }
            catch (AuthorizationException ex)
            {
                return BadRequest(ex.ErrorCode, ex.Message);
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

        private AccountModel Map(AccountDTO model)
        {
            return new AccountModel
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
