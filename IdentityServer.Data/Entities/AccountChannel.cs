using IdentityServer.Infrastructure;
using System.Collections.Generic;

namespace IdentityServer.Data.Entities
{
    public class AccountChannel : BaseEntity<int>
    {
        public int AccountID { get; set; }
        public int ChannelID { get; set; }
        public AccountChannelStatus Status { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        //public virtual ApplicationUser User { get; set;  }
        public virtual Channel Channel { get; set; }
        public virtual Account Account{ get; set; }
        public virtual ICollection<OTP> OTPs { get; set; }
    }
}
