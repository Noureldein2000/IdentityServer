using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data.Entities
{
    public class ChannelSim : BaseEntity<int>
    {
        public int ChannelID { get; set; }
        public virtual Channel Channel { get; set; }
        public string SimNumber { get; set; }
    }
}
