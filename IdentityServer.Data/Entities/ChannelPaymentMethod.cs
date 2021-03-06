using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data.Entities
{
    public class ChannelPaymentMethod : BaseEntity<int>
    {
        public string Name { get; set; }
        public string ArName { get; set; }
        public virtual ICollection<Channel> Channels { get; set; }
    }
}
