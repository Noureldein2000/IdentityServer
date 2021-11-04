using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class UserPermissionsModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<CheckBoxModel> UserClaims { get; set; }
    }
}
