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
    public class ChannelCategoryController : BaseController
    {
        private readonly IChannelCategoryService _channelCategoryService;
        public ChannelCategoryController(IChannelCategoryService channelCategoryService)
        {
            _channelCategoryService = channelCategoryService;
        }

        [HttpGet]
        [Route("GetAll")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<ChannelCategoryModel>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _channelCategoryService.GetChannelCategories().Select(a => Map(a));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #region Helper Method
        //Helper Method
        private ChannelCategoryModel Map(ChannelCategoryDTO model)
        {
            return new ChannelCategoryModel
            {
                Id = model.Id,
                Name = model.Name,
                NameAr = model.NameAr
            };
        }

        #endregion
    }
}
