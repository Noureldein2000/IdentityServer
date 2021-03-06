using IdentityServer.Infrastructure;
using System.Collections.Generic;

namespace IdentityServer.Data.Entities
{
    public class Account : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CommercialRegistrationNo { get; set; }
        public string TaxNo { get; set; }
        public bool Active { get; set; }
        public int? UpdateBy { get; set; }
        public int? Parent_CenterID { get; set; }
        public double? Total_Parent_Amount { get; set; }
        public bool? ProfitDailyControl { get; set; }
        public int? CreatedBy { get; set; }
        public int? AccountTypeProfileID { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? ActivityID { get; set; }
        public int? RegionID { get; set; }
        public int? EntityID { get; set; }
        public virtual Region Region { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual AccountTypeProfile AccountTypeProfile { get; set; }
        public virtual AccountOwner AccountOwner { get; set; }
        public virtual ICollection<AccountRelationMapping> AccountRelationMappings { get; set; }
        public virtual ICollection<AccountChannel> AccountChannels { get; set; }
        public virtual ICollection<AccountChannelHistory>  AccountChannelHistories{ get; set; }
        public virtual ICollection<AccountChannelType> AccountChannelTypes { get; set; }
    }
}
