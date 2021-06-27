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
        public int Status { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public virtual Channel Channel { get; set; }
    }
}
