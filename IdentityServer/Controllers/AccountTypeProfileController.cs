using IdentityServer.DTOs;
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
    public class AccountTypeProfileController : BaseController
    {
        private readonly IAccountTypeProfileService _accountTypeProfileService;
        public AccountTypeProfileController(IAccountTypeProfileService accountTypeProfileService)
        {
            _accountTypeProfileService = accountTypeProfileService;
        }

        [HttpGet]
        [Route("GetAll")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PagedResult<AccountTypeProfileModel>), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery]int pageNumber = 1, int pageSize = 10)
        {                                       
            try
            {
                var result = _accountTypeProfileService.GetAccountTypeProfileLst(pageNumber, pageSize);
                return Ok(new PagedResult<AccountTypeProfileModel>
                {
                    Results = result.Results.Select(ard => MapToModel(ard)).ToList(),
                    PageCount = result.PageCount
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("Add")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AccountTypeProfileModel), StatusCodes.Status200OK)]
        public IActionResult Add([FromBody] AccountTypeProfileModel model)
        {
            try
            {
                var result = _accountTypeProfileService.AddAccountTypeProfile(new AccountTypeProfileDTO
                {
                    Id = model.Id,
                    AccountTypeID = model.AccountTypeID,
                    ProfileID = model.ProfileID,
                });
                return Ok(MapToModel(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetAccountTypesAndProfiles")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AccountTypeProfileLstModel), StatusCodes.Status200OK)]
        public IActionResult GetAccountTypesAndProfiles()
        {
            try
            {
                var result = _accountTypeProfileService.GetLstAccountTypeAndProfile();
                return Ok(Map(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            try
            {
                _accountTypeProfileService.DeleteAccountTypeProfile(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetParentAccounts/{id}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<AccountModel>), StatusCodes.Status200OK)]
        public IActionResult GetParentAccounts(int id)
        {
            try
            {
                var result = _accountTypeProfileService.GetParentAccounts(id);
                return Ok(result.Select(s => Map(s)).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetProfilesByAccountTypeId/{id}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<AccountTypeProfileModel>), StatusCodes.Status200OK)]
        public IActionResult GetProfilesByAccountTypeId(int id)
        {
            try
            {
                var result = _accountTypeProfileService.GetProfilesByAccountTypeId(id);
                return Ok(result.Select(s => MapToModel(s)).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #region Helper Method
        //Helper Method
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
        private AccountTypeProfileLstModel Map(ListAccountTypeAndProfileDTO model)
        {
            return new AccountTypeProfileLstModel
            {
                LstProfile = model.LstProfile,
                LstAccountType = model.LstAccountType
            };
        }
        private AccountTypeProfileModel MapToModel(AccountTypeProfileDTO model)
        {
            return new AccountTypeProfileModel
            {
                Id = model.Id,
                AccountTypeID = model.AccountTypeID,
                ProfileID = model.ProfileID,
                FullName = model.FullName,
                AccountType=model.AccountTypeName,
                Profile=model.ProfileName
            };
        }

        #endregion

    }
}
