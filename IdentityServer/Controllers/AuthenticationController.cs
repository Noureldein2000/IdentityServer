using IdentityServer.Entities;
using IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static IdentityServer.Models.Constants;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthenticationController(UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var userClaims = _userManager.GetClaimsAsync(user).Result.Where(c => c.Value == AvaliableClaimValues.True);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                };
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                foreach (var claim in userClaims)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, claim.Type));
                }
                //authClaims.Add(new Claim("channel_id", "value"));
                var authSigninKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetValue<string>("IdentityServer:Secret")));
                var token = new JwtSecurityToken
                (
                    issuer: _configuration.GetValue<string>("IdentityServer:Issuer"),
                    audience: _configuration.GetValue<string>("IdentityServer:audience"),
                    claims: authClaims,
                    expires: DateTime.Now.AddDays(2),
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                 );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    privilages = userClaims.Where(s => s.Value == AvaliableClaimValues.True)
                                                .Select(s => s.Type).ToList()
                });
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("validateuser/{id}")]
        public async Task<IActionResult> ValidateUser(string id)
        {
            var result = new ValidateUserDataModel();
            var user = await _userManager.FindByIdAsync(id);
            if (user.LockoutEnabled && user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTime.Now)
            {
                result.IsBlocked = true;
                return Ok(result);
            }
            else
            {
                result.IsBlocked = false;
                return Ok(result);
            }
        }
    }
}
