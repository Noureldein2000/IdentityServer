using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.DTOs
{
    public class UserTokenRoleDTO
    {
        public string Token { get; set; }
        public string[] Permissions { get; set; }
    }
}
