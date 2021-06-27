using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class Account : BaseEntity<int>
    {
        public string CentralName { get; set; }
        public string CenterName { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CommNo { get; set; }
        public string TaxNo { get; set; }
        public int? Active { get; set; }
        public DateTime ChgTime { get; set; }
        public bool? AllowTransfeer { get; set; }
        public string NationalId { get; set; }
        public string Activity { get; set; }
        public string sim_no { get; set; }
        public bool? is_agent { get; set; }
        public string Date_To { get; set; }
        public int? UserUpdate { get; set; }
        public string MachineCode { get; set; }
        public string edDesc { get; set; }
        public bool? Logged_In { get; set; }
        public DateTime? Last_login { get; set; }
        public DateTime? last_logout { get; set; }
        public string last_channel { get; set; }
        public double? TotalPoints { get; set; }
        public string Serial { get; set; }
        public int? Centers_company_Id { get; set; }
        public int? Parent_CenterID { get; set; }
        public double? Total_Parent_Amount { get; set; }
        public bool? ProfitDailyControl { get; set; }
        public int? AccountTypeID { get; set; }
        public int? CreatedBy { get; set; }
        public int? AccountProfileID { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<AccountChannel> AccountChannels{ get; set; }
    }
}
