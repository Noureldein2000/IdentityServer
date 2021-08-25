using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class EditAccountModel
    {
        [Required]
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string AccountName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Email { get; set; }
        public string NationalID { get; set; }
        public string CommercialRegistrationNo { get; set; }
        public string TaxNo { get; set; }
        public int ActivityID { get; set; }
        public int? AccountTypeProfileID { get; set; }
        public int? RegionID { get; set; }
        public int? EntityID { get; set; }
        public int? ParentID { get; set; }
    }
}
