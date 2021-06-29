using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class Channel : BaseEntity<int>
    {
        public string Name { get; set; }
        public int ChannelTypeID { get; set; }
        public int ChannelOwnerID { get; set; }
        public string Serial { get; set; }
        public int PaymentMethodID { get; set; }

        public virtual ChannelType ChannelType { get; set; }
        public virtual ChannelPaymentMethod ChannelPaymentMethod { get; set; }
        public virtual ChannelOwner ChannelOwner { get; set; }
        public virtual ICollection<ChannelIdentifier> ChannelIdentifiers { get; set; }
        public virtual ICollection<AccountChannel> AccountChannels { get; set; }
        public virtual ICollection<ChannelSim> ChannelSims { get; set; }
    }
}
