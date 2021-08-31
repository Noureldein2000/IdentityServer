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
    public class ChannelTypeController : BaseController
    {
        private readonly IChannelTypeService _channelTypeService;
        public ChannelTypeController(IChannelTypeService channelTypeService)
        {
            _channelTypeService = channelTypeService;
        }

        [HttpGet]
        [Route("GetAll")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<ChannelTypeModel>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _channelTypeService.GetChannelTypes().Select(a => Map(a));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetByChannelCategoryId")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<ChannelTypeModel>), StatusCodes.Status200OK)]
        public IActionResult GetByChannelCategoryId(int id)
        {
            try
            {
                var result = _channelTypeService.GetByChannelCategoryId(id).Select(a => Map(a));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #region Helper Method
        //Helper Method
        private ChannelTypeModel Map(ChannelTypeDTO model)
        {
            return new ChannelTypeModel
            {
                ID = model.ID,
                Name = model.Name,
                NameAr = model.NameAr
            };
        }

        #endregion
    }
}
