using IdentityServer.DTOs;
using IdentityServer.Infrastructure;
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
    public class ChannelController : BaseController
    {
        private readonly IChannelService _channelService;

        public ChannelController(IChannelService channelService)
        {
            _channelService = channelService;
        }

        [HttpGet]
        [Route("GetChannels")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        public IActionResult GetChannels(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var result = _channelService.GetChannels(pageNumber, pageSize).Select(c => Map(c));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Add")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        public IActionResult Add([FromBody] AddChannelModel model)
        {
            try
            {
                var result = _channelService.AddChannel(new ChannelDTO
                {
                    Name = model.Name,
                    Serial = model.Serial,
                    ChannelTypeID = model.ChannelTypeID,
                    ChannelOwnerID = model.ChannelOwnerID,
                    PaymentMethodID = model.PaymentMethodID,
                    Status = model.Status,
                    Value = model.Value,
                    CreatedBy = UserIdentityId
                });
                return Ok(Map(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Edit")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        public IActionResult Edit([FromBody] EditChannelModel model)
        {
            try
            {
                var result = _channelService.EditChannel(new ChannelDTO
                {
                    ChannelID = model.ChannelId,
                    Name = model.Name,
                    Serial = model.Serial,
                    ChannelTypeID = model.ChannelTypeID,
                    ChannelOwnerID = model.ChannelOwnerID,
                    PaymentMethodID = model.PaymentMethodID,
                    Status = model.Status,
                    Value = model.Value,
                    UpdatedBy = UserIdentityId
                });
                return Ok(Map(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _channelService.DeleteChannel(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetChannelIdentitfiers/{channelId}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        public IActionResult GetChannelIdentitfiers(int channelId)
        {
            try
            {
                var result = _channelService.GetChannelIdentitfiers(channelId);
                return Ok(Map(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SearchChannelBySerial/{searchKey}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        public IActionResult SearchChannelBySerial(string searchKey, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var result = _channelService.SearchChannelBySerial(searchKey, pageNumber, pageSize).Select(c => Map(c));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #region Helper Method
        //Helper Method
        private ChannelResponseModel Map(ChannelDTO model)
        {
            return new ChannelResponseModel
            {
                Name = model.Name,
                Serial = model.Serial,
                ChannelTypeID = model.ChannelTypeID,
                ChannelOwnerID = model.ChannelOwnerID,
                PaymentMethodID = model.PaymentMethodID,
                Status = model.Status,
                Value = model.Value,
                CreatedBy = model.CreatedBy,
                CreationDate = model.CreationDate
            };
        }

        #endregion
    }
}
