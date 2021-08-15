using IdentityServer.Data.Entities;
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
                var authResponce = await _loginService.ValidateUser(new DTOs.AccountChannelLoginDTO
                {
                    AccountId = model.AccountId,
                    ChannelCategory = model.ChannelCategory,
                    ChannelId = model.ChannelId,
                    ChannelType = model.ChannelType,
                    Password = model.Password,
                    Username = model.Username,
                    AccountIP = GetIPAddress(),
                    LocalIP = GetLocalIpAddress()
                });
                var responce = new AuthorizationResponceModel
                {
                    Token = authResponce.Token,
                    Permissions = authResponce.Permissions,
                    ServerDate = authResponce.ServerDate,
                    LocalDate = authResponce.LocalDate,
                    AccountId = authResponce.AccountId,
                    AccountName = authResponce.AccountName,
                    AccountType = authResponce.AccountType,
                    Code = authResponce.Code,
                    Message = authResponce.Message,
                    ServiceListVersion = authResponce.ServiceListVersion,
                    Version = authResponce.Version
                };
                return Ok(responce);

            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.ErrorCode, ex.Message);
            }
            catch (OkException ex)
            {
                return Ok(ex.ErrorCode, ex.Message);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCodes.Unknown);
            }
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


        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword([FromBody] ChangePasswordModel model)
        {
            try
            {
                var passData = _loginService.ChangePassword(new DTOs.ChangePasswordDTO
                {
                    AccountId = model.AccountId,
                    ChannelId = model.ChannelId,
                    ChannelType = model.ChannelType,
                    NewPassword = model.NewPassword,
                    Password = model.Password,
                    Username = model.Username,
                });
                return Ok(passData);
            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.ErrorCode, ex.Message);
            }
            catch (OkException ex)
            {
                return Ok(ex.ErrorCode, ex.Message);
            }
        }
        [HttpPost]
        [Route("ConfirmOTP")]
        public IActionResult ConfirmOTP([FromBody] ConfirmOTPModel model)
        {
            try
            {
                var passData = _loginService.ConfirmOTP(new DTOs.ConfirmOTPDTO
                {
                    AccountId = model.AccountId,
                    ChannelId = model.ChannelId,
                    ChannelType = model.ChannelType,
                    Password = model.Password,
                    Username = model.Username,
                    Id = model.Id,
                    OTP = model.OTP
                });
                return Ok(passData);
            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.ErrorCode, ex.Message);
            }
            catch (OkException ex)
            {
                return Ok(ex.ErrorCode, ex.Message);
            }
        }
        [HttpPost]
        [Route("ResendOTP")]
        public IActionResult ResendOTP([FromBody] ConfirmOTPModel model)
        {
            try
            {
                var passData = _loginService.ResendOTP(new DTOs.ConfirmOTPDTO
                {
                    AccountId = model.AccountId,
                    ChannelId = model.ChannelId,
                    ChannelType = model.ChannelType,
                    Password = model.Password,
                    Username = model.Username,
                    Id = model.Id,
                    OTP = model.OTP
                });
                return Ok(passData);
            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.ErrorCode, ex.Message);
            }
            catch (OkException ex)
            {
                return Ok(ex.ErrorCode, ex.Message);
            }
        }
    }
}
