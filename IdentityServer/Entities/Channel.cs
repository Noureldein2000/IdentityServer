using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class Channel : BaseEntity<int>
    {
        //Primary Fields
        public string Name { get; set; }
        public int NameChannelTypeID { get; set; }
        public int ChannelOwnerID { get; set; }
        public string Serial { get; set; }
        public int PaymentMethodID { get; set; }

        //Relational Entitiy
        public ChannelType ChannelType { get; set; }
        public ChannelPaymentMethod ChannelPaymentMethod { get; set; }
        public ChannelOwner ChannelOwner { get; set; }
        public ChannelIdentifier ChannelIdentifier { get; set; }
        public ICollection<AccountChannel> AccountChannels { get; set; }
        public ICollection<ChannelCategory> ChannelCategories { get; set; }

    }
}
