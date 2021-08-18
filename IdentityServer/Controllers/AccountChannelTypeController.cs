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
    public class AccountChannelTypeController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountChannelTypeController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("GetAccountChannelTypes/{accountId}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        public IActionResult GetAccountChannelTypes([FromRoute] int accountId)
        {
            try
            {
                var result = _accountService.GetAccountChannelTypes(accountId).Select(ard => Map(ard));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("EditAccountChannelTypes")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        public IActionResult Edit([FromBody] EditAccountChannelTypeModel model)
        {
            try
            {
                var result = _accountService.EditAccountChannelTypes(
                    new AccountChannelTypeDTO
                    {
                        Id = model.Id,
                        HasLimitedAccess = model.HasLimitedAccess,
                        ExpirationPeriod = model.ExpirationPeriod
                    });
                return Ok(Map(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("DeleteAccountChannelTypes/{Id}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                _accountService.DeleteAccountChannelTypes(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("AddAccountChannelTypes")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        public IActionResult Add([FromBody] AddAccountChannelTypeModel model)
        {
            try
            {
                _accountService.AddAccountChannelTypes(new AccountChannelTypeDTO
                {
                    AccountID = model.AccountID,
                    ChannelTypeID = model.ChannelTypeID,
                    HasLimitedAccess = model.HasLimitedAccess,
                    ExpirationPeriod = model.ExpirationPeriod
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #region Helper Method
        //Helper Method
        private AccountChannelTypeModel Map(AccountChannelTypeDTO model)
        {
            return new AccountChannelTypeModel
            {
                Id = model.Id,
                AccountID = model.AccountID,
                ChannelTypeID = model.ChannelTypeID,
                ChannelTypeName = model.ChannelTypeName,
                ExpirationPeriod = model.ExpirationPeriod,
                HasLimitedAccess = model.HasLimitedAccess
            };
        }

        #endregion

    }
}
