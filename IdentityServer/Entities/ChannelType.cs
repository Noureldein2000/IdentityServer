using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class ChannelType : BaseEntity<int>
    {
        public string Name { get; set; }
        public string ArName { get; set; }
        public int? Version { get; set; }
        public int ChannelCategoryID { get; set; }

        public virtual ICollection<Channel> Channels { get; set; }
        public virtual ChannelCategory ChannelCategory { get; set; }
        public virtual ICollection<AccountChannelType> AccountChannelTypes { get; set; }

    }
}
