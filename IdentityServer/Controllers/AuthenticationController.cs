using IdentityServer.Entities;
using IdentityServer.Helpers;
using IdentityServer.Infrastructure;
using IdentityServer.Models;
using IdentityServer.Properties;
using IdentityServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Claims;
using System.Threading.Tasks;
using static IdentityServer.Models.Constants;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILoginService _loginService;
        public AuthenticationController(UserManager<ApplicationUser> userManager,
            IConfiguration configuration, ILoginService loginService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _loginService = loginService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    if (user.LockoutEnabled && user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTime.Now)
                        return BadRequest(Resources.GeneralError);

                    var authResponce = _loginService.GetAccountChannelData(new DTOs.AccountChannelDTO
                    {
                        MustChangePassword = user.MustChangePassword,
                        AccountId = model.AccountId,
                        ChannelTypeId = model.ChannelType,
                        ChannelId = model.ChannelId,
                        UserId = user.UserId,
                        AccountIP = GetIPAddress(),
                        LocalIP = GetLocalIpAddress()
                    });

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
                    authClaims.Add(new Claim("channel_id", model.ChannelId));
                    authClaims.Add(new Claim("account_id", model.AccountId.ToString()));
                    var authSigninKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetValue<string>("IdentityServer:Secret")));
                    var token = new JwtSecurityToken
                    (
                        issuer: _configuration.GetValue<string>("IdentityServer:Issuer"),
                        audience: _configuration.GetValue<string>("IdentityServer:audience"),
                        claims: authClaims,
                        expires: DateTime.Now.AddDays(authResponce.ExpirationPeriod),
                        signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                     );
                    var responce = new AuthorizationResponceModel
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Privilages = userClaims.Where(s => s.Value == AvaliableClaimValues.True)
                                                    .Select(s => s.Type).ToArray(),
                        ServerDate = authResponce.ServerDate,
                        LocalDate = authResponce.LocalDate,
                        AccountId = authResponce.AccountId,
                        AccountName = authResponce.AccountName,
                        AccountType = authResponce.AccountType
                    };
                    return Ok(responce);
                }
            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.ErrorCode, ex.Message);
            }
            catch (OkException ex)
            {
                return Ok(ex.ErrorCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorCodes.Unknown);
            }

            return Unauthorized(Resources.NoAuth);
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
