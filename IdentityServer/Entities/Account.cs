using IdentityServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class Account : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CommercialRegistrationNo { get; set; } 
        public string TaxNo { get; set; }
        public ActiveStatus Active { get; set; }
        public string Activity { get; set; }
        public int? UpdateBy { get; set; }
        public int? Parent_CenterID { get; set; }
        public double? Total_Parent_Amount { get; set; }
        public bool? ProfitDailyControl { get; set; }
        public int? AccountTypeID { get; set; }
        public int? CreatedBy { get; set; }
        public int? AccountProfileID { get; set; }
        public string Latitude { get; set; }
        public string longitude { get; set; }
        //public int ActivityID { get; set; }
        //public virtual Activity Activity { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual AccountOwner AccountOwner { get; set; }
        public virtual ICollection<AccountChannel> AccountChannels{ get; set; }
        public virtual ICollection<AccountChannelType> AccountChannelTypes { get; set; }
    }
}
