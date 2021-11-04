using IdentityServer.DTOs;
using IdentityServer.Helpers;
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
        [ProducesResponseType(typeof(PagedResult<ChannelResponseModel>), StatusCodes.Status200OK)]
        public IActionResult GetChannels(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var result = _channelService.GetChannels(pageNumber, pageSize);
                return Ok(new PagedResult<ChannelResponseModel>()
                {
                    Results = result.Results.Select(ard => Map(ard)).ToList(),
                    PageCount = result.PageCount
                });
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
        [ProducesResponseType(typeof(ChannelResponseModel), StatusCodes.Status200OK)]
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
                    CreatedBy = UserIdentityId,
                    AccountId=model.AccountId
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
        [ProducesResponseType(typeof(ChannelResponseModel), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(ChannelResponseModel), StatusCodes.Status200OK)]
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
        [Route("SearchChannels")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PagedResult<ChannelResponseModel>), StatusCodes.Status200OK)]
        public IActionResult SearchChannels(int? dropDownFilter, int? dropDownFilter2, string searchKey, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var result = _channelService.SearchChannelBySerial(dropDownFilter,dropDownFilter2 , searchKey, pageNumber, pageSize);
                return Ok(new PagedResult<ChannelResponseModel>()
                {
                    Results = result.Results.Select(ard => Map(ard)).ToList(),
                    PageCount = result.PageCount
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SearchSpecificChannelBySerial/{searchKey}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PagedResult<ChannelResponseModel>), StatusCodes.Status200OK)]
        public IActionResult SearchSpecificChannelBySerial(string searchKey, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var result = _channelService.SearchSpecificChannelBySerial(searchKey, pageNumber, pageSize);
                return Ok(new PagedResult<ChannelResponseModel>()
                {
                    Results = result.Results.Select(ard => Map(ard)).ToList(),
                    PageCount = result.PageCount
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ChangeStatus/{Id}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        public IActionResult ChangeStatus([FromRoute] int Id)
        {
            try
            {
                var result = _channelService.ChangeStatus(Id, UserIdentityId);
                return Ok(result);
            }
            catch (AuthorizationException ex)
            {
                return BadRequest(ex.ErrorCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #region Helper Method
        //Helper Method
        private ChannelResponseModel Map(ChannelDTO model)
        {
            return new ChannelResponseModel
            {
                ChannelID = model.ChannelID,
                Name = model.Name,
                Serial = model.Serial,
                ChannelTypeID = model.ChannelTypeID,
                ChannelTypeName = model.ChannelTypeName,
                ChannelOwnerID = model.ChannelOwnerID,
                ChannelOwnerName = model.ChannelOwnerName,
                PaymentMethodID = model.PaymentMethodID,
                PaymentMethodName = model.PaymentMethodName,
                Status = model.Status,
                Value = model.Value,
                CreatedBy = model.CreatedBy,
                CreationDate = model.CreationDate
            };
        }

        #endregion
    }
}
