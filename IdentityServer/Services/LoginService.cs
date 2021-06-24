using IdentityServer.Entities;
using IdentityServer.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class LoginService : ILoginService
    {
        private readonly IBaseRepository<UserToken, int> _baseRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public LoginService(IBaseRepository<UserToken, int> baseRepository,
            UserManager<ApplicationUser> userManager)
        {
            _baseRepository = baseRepository;
            _userManager = userManager;
        }
    }
}
