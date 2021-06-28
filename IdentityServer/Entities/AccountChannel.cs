using IdentityServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class AccountChannel : BaseEntity<int>
    {
        public int AccountID { get; set; }
        public int ChannelID { get; set; }
        public ActiveStatus Status { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        //public virtual ApplicationUser User { get; set; }
        public virtual Channel Channel { get; set; }
        public virtual Account Account{ get; set; }
        public virtual ICollection<OTP> OTPs { get; set; }
    }
}
