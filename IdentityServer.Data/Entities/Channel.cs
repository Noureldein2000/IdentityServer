using System.Collections.Generic;

namespace IdentityServer.Data.Entities
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
        public virtual ChannelIdentifier ChannelIdentifiers { get; set; }
        public virtual ICollection<AccountChannel> AccountChannels { get; set; }
        public virtual ICollection<AccountChannelHistory> AccountChannelHistories { get; set; }
        public virtual ICollection<ChannelSim> ChannelSims { get; set; }
    }
}
