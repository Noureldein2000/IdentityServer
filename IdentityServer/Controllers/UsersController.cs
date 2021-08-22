using IdentityServer.Data.Entities;
using IdentityServer.Data.Seeding;
using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationUser> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UsersController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationUser> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpGet("Account/{accountId}")]
        [ProducesResponseType(typeof(PagedResult<UserModel>), StatusCodes.Status200OK)]
        public IActionResult Account([FromRoute] string accountId)
        {
            var users = _userManager.Users.Where(u => u.ReferenceID == accountId).Select(u => new UserModel
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                Roles = string.Join(", ", _userManager.GetRolesAsync(u).Result)
            });

            return Ok(new PagedResult<UserModel>
            {
                Results = users.OrderBy(u => u.UserName).ToList(),
                PageCount = users.Count()
            });
        }
        [HttpGet("GetAllAdmin")]
        [ProducesResponseType(typeof(PagedResult<UserModel>), StatusCodes.Status200OK)]
        public IActionResult GetAllAdmin([FromQuery] int pageNumber = 1, int pageSize = 10)
        {
            var users = _userManager.Users.Where(u => u.ReferenceID == null).Select(u => new UserModel
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                Roles = string.Join(", ", _userManager.GetRolesAsync(u).Result)
            });

            return Ok(new PagedResult<UserModel>
            {
                Results = users.OrderBy(u => u.UserName).Skip(pageNumber - 1).Take(pageSize).ToList(),
                PageCount = users.Count()
            });
        }
        [HttpGet("ManageRoles")]
        [ProducesResponseType(typeof(UserRolesModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return BadRequest();

            var roles = _roleManager.Roles.ToList();
            var model = new UserRolesModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(r => new CheckBoxModel
                {
                    DisplayName = r.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, r.Name).Result
                }).ToList()
            };

            return Ok(model);
        }
        [HttpPost("ManageRoles")]
        public async Task<IActionResult> ManageRoles(UserRolesModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return BadRequest();

            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user, 
                model.Roles.Where(r => r.IsSelected).Select(r => r.DisplayName));

            return Ok(model);
        }
        [HttpGet("ManagePermissions")]
        public async Task<IActionResult> ManagePermissions(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return BadRequest();

            var userClaims = _userManager.GetClaimsAsync(user).Result.Select(c => c.Value).ToList();
            var allDenies = Denies.GenerateAllDenies().Select(p => new CheckBoxModel
            {
                DisplayName = p,
            }).ToList();
            foreach (var p in allDenies)
            {
                if (userClaims.Any(c => c == p.DisplayName))
                    p.IsSelected = true;
            }

            var model = new UserPermissionsModel
            {
                UserId = userId,
                UserName = user.UserName,
                UserClaims = allDenies
            };

            return Ok(model);
        }
        [HttpPost("ManagePermissions")]
        [ProducesResponseType(typeof(RolePermissionsModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> ManagePermissions(UserPermissionsModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return BadRequest();

            var userClaims = await _userManager.GetClaimsAsync(user);
            foreach (var claim in userClaims)
            {
                await _userManager.RemoveClaimAsync(user, claim);
            }
            var selectedClaims = model.UserClaims.Where(c => c.IsSelected).ToList();
            foreach (var claim in selectedClaims)
            {
                await _userManager.AddClaimAsync(user, new Claim("Deny", claim.DisplayName));
            }
            return Ok(model);
        }
    }
}
