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
        public int Version { get; set; }
        public int ChannelCategoryID { get; set; }

        //Relational Entity
        public ICollection<Channel> Channels { get; set; }
        public ChannelCategory ChannelCategory { get; set; }
        public ICollection<AccountChannelType> AccountChannelTypes { get; set; }

    }
}
