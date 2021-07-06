using IdentityServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class AccountType:BaseEntity<int>
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public ActiveStatus Status { get; set; }
        public int? TreeLevel { get; set; }

        public virtual ICollection<AccountTypeProfile> AccountTypeProfiles { get; set; }
    }
}
