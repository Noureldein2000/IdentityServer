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
    public class ChannelOwnerController : BaseController
    {
        private readonly IChannelOwnerService _channelOwnerService;
        public ChannelOwnerController(IChannelOwnerService  channelOwnerService)
        {
            _channelOwnerService = channelOwnerService;
        }
        [HttpGet]
        [Route("GetAll")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<ChannelOwnerModel>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _channelOwnerService.GetChannelOwners().Select(a => Map(a));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #region Helper Method
        //Helper Method
        private ChannelOwnerModel Map(ChannelOwnerDTO model)
        {
            return new ChannelOwnerModel
            {
                ID = model.ID,
                Name = model.Name,
                NameAr = model.NameAr
            };
        }

        #endregion

    }
}
