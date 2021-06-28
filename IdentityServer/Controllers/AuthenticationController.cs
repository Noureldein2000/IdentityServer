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
    public class AuthenticationController : ControllerBase
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

        private string GetIPAddress()
        {
            HttpContext context = HttpContext;
            string ipAddress = context.GetServerVariable("HTTP_X_FORWARDED_FOR");

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.GetServerVariable("REMOTE_ADDR");
        }
        private string GetLocalIpAddress()
        {
            UnicastIPAddressInformation mostSuitableIp = null;

            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var network in networkInterfaces)
            {
                if (network.OperationalStatus != OperationalStatus.Up)
                    continue;

                var properties = network.GetIPProperties();

                if (properties.GatewayAddresses.Count == 0)
                    continue;

                foreach (var address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;

                    if (IPAddress.IsLoopback(address.Address))
                        continue;

                    if (!address.IsDnsEligible)
                    {
                        if (mostSuitableIp == null)
                            mostSuitableIp = address;
                        continue;
                    }

                    // The best IP is the IP got from DHCP server
                    if (address.PrefixOrigin != PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                            mostSuitableIp = address;
                        continue;
                    }

                    return address.Address.ToString();
                }
            }

            return mostSuitableIp != null
                ? mostSuitableIp.Address.ToString()
                : "";
        }

        [NonAction]
        public IActionResult Unauthorized(string errorCode, string errorMessage)
        {
            var response = new AuthorizationErrorMessages
            {
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            };
            return Unauthorized(response);
        }
        [NonAction]
        public IActionResult Ok(string errorCode, string errorMessage)
        {
            var response = new AuthorizationErrorMessages
            {
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            };
            return Ok(response);
        }
    }
}
