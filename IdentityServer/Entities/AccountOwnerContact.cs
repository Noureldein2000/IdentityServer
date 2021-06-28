using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class AccountOwnerContact : BaseEntity<int>
    {
        public int AccountOwnerID { get; set; }
        public virtual AccountOwner AccountOwner { get; set; }
        public string Mobile { get; set; }
    }
}
