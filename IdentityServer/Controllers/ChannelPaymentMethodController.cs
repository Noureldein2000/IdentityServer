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
    public class ChannelPaymentMethodController : BaseController
    {
        private readonly IChannelPaymentMethodService _channelPaymentMethodService;
        public ChannelPaymentMethodController(IChannelPaymentMethodService channelPaymentMethodService)
        {
            _channelPaymentMethodService = channelPaymentMethodService;
        }

        [HttpGet]
        [Route("GetAll")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<ChannelPaymentMethodModel>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _channelPaymentMethodService.GetChannelPaymentMethods().Select(a => Map(a));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #region Helper Method
        //Helper Method
        private ChannelPaymentMethodModel Map(ChannelPaymentMethodDTO model)
        {
            return new ChannelPaymentMethodModel
            {
                ID = model.ID,
                Name = model.Name,
                NameAr = model.NameAr
            };
        }

        #endregion

    }
}
