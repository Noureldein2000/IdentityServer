using IdentityServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data.Entities
{
    public class Profile :BaseEntity<int>
    {
        public string Name{ get; set; }
        public string NameAr{ get; set; }
        public ActiveStatus Status { get; set; }

        public virtual ICollection<AccountTypeProfile> AccountTypeProfiles { get; set; }
    }
}
