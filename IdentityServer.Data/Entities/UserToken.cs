using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data.Entities
{
    public class UserToken : BaseEntity<int>
    {
        public int UserID { get; set; }
        public string Token { get; set; }
        public bool IsValid { get; set; }
        //public virtual ApplicationUser User { get; set; }
    }
}
