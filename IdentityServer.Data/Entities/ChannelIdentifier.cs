using IdentityServer.Infrastructure;

namespace IdentityServer.Data.Entities
{
    public class ChannelIdentifier : BaseEntity<int>
    {
        public string Value { get; set; }
        public ActiveStatus Status { get; set; }
        public int ChannelID { get; set; }
        public int CreatedBy { get; set; }
        //public virtual ApplicationUser User { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual Channel Channel { get; set; }
    }
}
