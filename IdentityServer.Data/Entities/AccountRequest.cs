using IdentityServer.Infrastructure;

namespace IdentityServer.Data.Entities
{
    public class AccountRequest : BaseEntity<int>
    {
        public string OwnerName { get; set; }
        public string AccountName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string NationalID { get; set; }
        public string CommercialRegistrationNo { get; set; }
        public string TaxNo { get; set; }
        public int ActivityID { get; set; }
        public virtual Activity Activity { get; set; }
        public AccountRequestStatus AccountRequestStatus { get; set; }
        public int? CreatedBy { get; set; }
        public int? RegionID { get; set; }
        public virtual Region Region { get; set; }
    }
}
