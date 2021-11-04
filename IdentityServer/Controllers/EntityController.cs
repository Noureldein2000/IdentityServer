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
    public class EntityController : BaseController
    {
        private readonly IEntityService _entityService;
        public EntityController(IEntityService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        [Route("GetAll")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<EntityModel>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _entityService.GetEntities().Select(a => Map(a));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Helper Method
        #region Helper Method
        private EntityModel Map(EntityDTO model)
        {
            return new EntityModel
            {
                ID = model.ID,
                Name = model.Name,
                NameAr = model.NameAr
            };
        }
        #endregion

    }
}
