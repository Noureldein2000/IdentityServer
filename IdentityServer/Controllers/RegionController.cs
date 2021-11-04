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
    public class RegionController : BaseController
    {
        private readonly IRegionService _regionService;
        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        [Route("GetGovernorate")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<RegionModel>), StatusCodes.Status200OK)]
        public IActionResult GetGovernorate()
        {
            try
            {
                var result = _regionService.GetGovernorate().Select(g => Map(g));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetRegionByGovernorateId/{id}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<RegionModel>), StatusCodes.Status200OK)]
        public IActionResult GetRegionByGovernorateId(int id)
        {
            try
            {
                var result = _regionService.GetRegion(id).Select(g => Map(g)); ;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #region Helper Method
        //Helper Method
        private RegionModel Map(RegionDTO model)
        {
            return new RegionModel
            {
                ID = model.ID,
                name = model.Name,
                GovernorateID = model.GovernorateID
            };
        }

        #endregion
    }
}
