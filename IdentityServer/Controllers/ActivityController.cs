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
    public class ActivityController : BaseController
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        [Route("GetAll")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<ActivityModel>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _activityService.GetActivities().Select(a=>Map(a));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #region Helper Method
        //Helper Method
        private ActivityModel Map(ActivityDTO model)
        {
            return new ActivityModel
            {
                ID = model.ID,
                Name = model.Name,
                NameAr = model.NameAr
            };
        }

        #endregion
    }
}
