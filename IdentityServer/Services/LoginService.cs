using IdentityServer.Entities;
using IdentityServer.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class LoginService : ILoginService
    {
        private readonly IBaseRepository<UserToken, int> _baseRepository;
        public LoginService(IBaseRepository<UserToken, int> baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
