using System.Collections.Generic;

namespace IdentityServer.Data.Entities
{
    public class ChannelCategory : BaseEntity<int>
    {
        public string Name { get; set; }
        public string ArName { get; set; }
        public virtual ICollection<ChannelType> ChannelTypes { get; set; }
    }
}
