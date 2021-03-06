using IdentityServer.DTOs;
using IdentityServer.Helpers;
using IdentityServer.Infrastructure;
using IdentityServer.Models;
using IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
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
        private readonly IStringLocalizer<AuthenticationResource> _localizer;
        public AccountController(IAccountService accountService, IStringLocalizer<AuthenticationResource> localizer)
        {
            _accountService = accountService;
            _localizer = localizer;
        }

        [HttpPost]
        [Route("AddAccountRequest")]
        [Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [ProducesResponseType(typeof(AccountRequestModel), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(AccountModel), StatusCodes.Status200OK)]
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
                    EntityID = addAccountModel.EntityID,
                    ParentID = addAccountModel.ParentID
                });

                return Ok(Map(result));
            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.ErrorCode, ex.Message);
            }
            catch (OkException ex)
            {
                return BadRequest(ex.ErrorCode, ex.Message);
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
        [ProducesResponseType(typeof(AccountModel), StatusCodes.Status200OK)]
        public IActionResult EditAccount([FromBody] EditAccountModel editAccountModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("102", string.Join(", ", ModelState.Values));

                var result = _accountService.EditAccount(new AccountDTO
                {
                    Id = editAccountModel.Id,
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
                    EntityID = editAccountModel.EntityID,
                    ParentID = editAccountModel.ParentID
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
        [ProducesResponseType(typeof(AccountRequestModel), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(AccountModel), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(PagedResult<AccountRequestModel>), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(PagedResult<AccountModel>), StatusCodes.Status200OK)]
        public IActionResult GetAccounts(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var result = _accountService.GetAccounts(pageNumber, pageSize);
                return Ok(new PagedResult<AccountModel>
                {
                    Results = result.Results.Select(ard => Map(ard)).ToList(),
                    PageCount = result.PageCount
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAccountsBySearchKey")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PagedResult<AccountModel>), StatusCodes.Status200OK)]
        public IActionResult GetAccountsBySearchKeys([FromQuery] int? accountType = null,string searchKey = null,int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var result = _accountService.GetAccountsBySearchKey(accountType,searchKey, pageNumber, pageSize);
                return Ok(new PagedResult<AccountModel>
                {
                    Results = result.Results.Select(ard => Map(ard)).ToList(),
                    PageCount = result.PageCount
                });
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


        [NonAction]
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
        [NonAction]
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
                ActivityName = model.ActivityName,
                CreatedBy = model.CreatedBy,
                GovernerateID = model.GovernerateID,
                AccountTypeProfileID = model.AccountTypeProfileID,
                CreationDate = model.CreationDate,
                EntityID = model.EntityID,
                ParentID = model.ParentID,
                RegionID = model.RegionID,
                UpdatedBy = model.UpdatedBy,
                Status = model.Status
            };
        }
    }
}
