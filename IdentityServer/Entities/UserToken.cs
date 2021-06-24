using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class UserToken : BaseEntity<int>
    {
        public string UserID { get; set; }
        public string Token { get; set; }
        public bool IsValid { get; set; }
    }
}
