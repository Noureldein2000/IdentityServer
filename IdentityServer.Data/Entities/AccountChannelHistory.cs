using IdentityServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Data.Entities
{
   public class AccountChannelHistory : BaseEntity<int>
    {
        public int AccountID { get; set; }
        public int ChannelID { get; set; }
        public AccountChannelStatus Status { get; set; }
        public string Reason { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual Channel Channel { get; set; }
        public virtual Account Account { get; set; }
    }
}
