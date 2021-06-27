using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class Profile :BaseEntity<int>
    {
        public string Name{ get; set; }
        public string NameAr{ get; set; }
        public int Status{ get; set; }

        public virtual ICollection<AccountProfile> AccountProfiles { get; set; }
    }
}
