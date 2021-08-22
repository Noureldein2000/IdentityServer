using IdentityServer.Data.Seeding;
using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {

        }
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<IdentityRole>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        [HttpPost("Add")]
        [ProducesResponseType(typeof(RoleModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(RoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _roleManager.RoleExistsAsync(model.Name))
            {
                ModelState.AddModelError("Name", "Role is exist");
                return BadRequest(ModelState);
            }
            await _roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));
            return Ok(model);

        }

        [HttpGet("ManagePermissions")]
        [ProducesResponseType(typeof(RolePermissionsModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> ManagePermissions(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return NotFound();

            var roleClaims = _roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();
            var allPermissions = Permissions.GenerateAllPermissions().Select(p => new CheckBoxModel
            {
                DisplayName = p,
            }).ToList();
            foreach (var p in allPermissions)
            {
                if (roleClaims.Any(c => c == p.DisplayName))
                    p.IsSelected = true;
            }

            var model = new RolePermissionsModel
            {
                RoleId = roleId,
                RoleName = role.Name,
                RoleClaims = allPermissions
            };

            return Ok(model);
        }
        [HttpPost("ManagePermissions")]
        [ProducesResponseType(typeof(RolePermissionsModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> ManagePermissions(RolePermissionsModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            if (role == null)
                return BadRequest();

            var roleClaims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in roleClaims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }
            var selectedClaims = model.RoleClaims.Where(c => c.IsSelected).ToList();
            foreach (var claim in selectedClaims)
            {
                await _roleManager.AddClaimAsync(role, new Claim("Permission", claim.DisplayName));
            }
            return Ok(model);
        }
    }
}
