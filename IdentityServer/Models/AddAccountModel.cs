using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class AddAccountModel
    {
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Address { get; set; }

        public string Email { get; set; }
        [Required]
        public string NationalID { get; set; }
        [Required]
        public string CommercialRegistrationNo { get; set; }
        [Required]
        public string TaxNo { get; set; }
        [Required]
        public int ActivityID { get; set; }
        [Required]
        public int? AccountTypeProfileID { get; set; }
        public int? RegionID { get; set; }
        public int? EntityID { get; set; }
    }
}
