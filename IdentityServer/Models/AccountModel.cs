using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string AccountName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string NationalID { get; set; }
        public string CommercialRegistrationNo { get; set; }
        public string TaxNo { get; set; }
        public int? ActivityID { get; set; }
        public string ActivityName { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int? AccountTypeProfileID { get; set; }
        public int? RegionID { get; set; }
        public int? GovernerateID { get; set; }
        public int? EntityID { get; set; }
        public int? ParentID { get; set; }
        public bool Status { get; set; }
    }
}
