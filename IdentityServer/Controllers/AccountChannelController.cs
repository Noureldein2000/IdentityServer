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
        [ProducesResponseType(typeof(IEnumerable<AccountChannelModel>), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(AccountChannelModel), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(AccountChannelModel), StatusCodes.Status200OK)]
        public IActionResult ChangeStatusAccountChannel([FromRoute] int id)
        {
            try
            {
                var result = _accountService.ChangeAccountChannelStatus(id, UserIdentityId);
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
        [ProducesResponseType(typeof(AccountChannelModel), StatusCodes.Status200OK)]
        public IActionResult DeleteAccountChannel([FromRoute] int id)
        {
            try
            {
                var result = _accountService.DeleteAccountChannel(id);
                return Ok(Map(result));
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
                ChannelName = model.ChannelName,
                Serial=model.Serial,
                Status = model.Status,
                CreatedBy = model.CreatedBy,
                CreatedName = model.CreatedName,
                UpdatedBy = model.UpdatedBy
            };
        }

        #endregion

    }
}
