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
    public class AccountChannelController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountChannelController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("GetChannelsByAccountId/{accountId}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        public IActionResult GetChannelsByAccountId([FromRoute] int accountId)
        {
            try
            {
                var result = _accountService.GetChannelsByAccountId(accountId).Select(ard => Map(ard));
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
        public IActionResult AddAccountChannel([FromBody] AccountChannelModel model)
        {
            try
            {
                var result = _accountService.AddAccountChannel(new AccountChannelDTO
                {
                    AccountID = model.AccountID,
                    ChannelID = model.ChannelID,
                    Status = model.Status,
                    CreatedBy = UserIdentityId
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("ChangeStatus/{id}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        public IActionResult ChangeStatusAccountChannel([FromRoute] int id)
        {
            try
            {
                var result = _accountService.ChangeAccountChannelStatus(id);

                return Ok(result);
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
        public IActionResult DeleteAccountChannel([FromRoute] int id)
        {
            try
            {
                _accountService.DeleteAccountChannel(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        #region Helper Method
        //Helper Method
        private AccountChannelModel Map(AccountChannelDTO model)
        {
            return new AccountChannelModel
            {
                Id = model.Id,
                AccountID = model.AccountID,
                ChannelID = model.ChannelID,
                Status = model.Status,
                CreatedBy = model.CreatedBy,
                UpdatedBy = model.UpdatedBy
            };
        }

        #endregion

    }
}
