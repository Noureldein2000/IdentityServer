using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class Activity : BaseEntity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<AccountRequest> AccountRequests { get; set; }
        //public virtual ICollection<Account> Accounts { get; set; }
    }
}
