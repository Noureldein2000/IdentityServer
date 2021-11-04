using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data.Entities
{
    public class Governorate : BaseEntity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }
}
