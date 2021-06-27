using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class ChannelCategory:BaseEntity<int>
    {
        public string Name { get; set; }
        public string ArName { get; set; }
        public virtual ICollection<ChannelType> ChannelTypes { get; set; }
    }
}
