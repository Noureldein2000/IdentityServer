using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class RolePermissionsModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<CheckBoxModel> RoleClaims { get; set; }
    }
}
