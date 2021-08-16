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
        public IActionResult GetAll([FromQuery]int pageNumber = 1, int pageSize = 10)
        {                                       
            try
            {
                var result = _accountTypeProfileService.GetAccountTypeProfileLst(pageNumber, pageSize).Select(ard => MaptoModel(ard));
                return Ok(result);
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
        public IActionResult Add([FromBody] AccountTypeProfileModel model)
        {
            try
            {
                var result = _accountTypeProfileService.AddAccountTypeProfile(new AccountTypeProfileDTO
                {
                    Id = model.Id,
                    AccountTypeID = model.AccountTypeID,
                    AccountTypeName = model.AccountTypeName,
                    ProfileID = model.ProfileID,
                    ProfileName = model.ProfileName

                });
                return Ok(MaptoModel(result));
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

        #region Helper Method
        //Helper Method
        private AccountTypeProfileLstModel Map(ListAccountTypeAndProfileDTO model)
        {
            return new AccountTypeProfileLstModel
            {
                lstProfile = model.LstProfile,
                lstAccountType = model.LstAccountType
            };
        }

        private AccountTypeProfileModel MaptoModel(AccountTypeProfileDTO model)
        {
            return new AccountTypeProfileModel
            {
                Id = model.Id,
                AccountTypeID = model.AccountTypeID,
                AccountTypeName = model.AccountTypeName,
                ProfileID = model.ProfileID,
                ProfileName = model.ProfileName
            };
        }

        #endregion

    }
}
