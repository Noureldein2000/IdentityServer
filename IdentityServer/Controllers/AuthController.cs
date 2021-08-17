using IdentityServer.Data.Entities;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var viewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
            //if (user != null && result == PasswordVerificationResult.Success)
            //{
            //    return Redirect(model.ReturnUrl);
            //}
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }

            //else if (result.IsLockedOut)
            //{

            //}
            return View(model);
        }
    }
}
