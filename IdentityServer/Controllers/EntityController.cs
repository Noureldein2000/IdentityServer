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
    public class EntityController : BaseController
    {
        private readonly IEntityService _entityService;
        public EntityController(IEntityService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        [Route("GetEntities")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        public IActionResult GetEntities()
        {
            try
            {
                var result = _entityService.GetEntities();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #region Helper Method
        //Helper Method
        //private RegionModel Map(RegionDTO model)
        //{
        //    return new RegionModel
        //    {
        //        ID = model.ID,
        //        name = model.Name,
        //        GovernorateID = model.GovernorateID
        //    };
        //}

        #endregion

    }
}
