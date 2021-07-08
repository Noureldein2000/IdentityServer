using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data.Entities
{
    public class OTP : BaseEntity<int>
    {
        public int UserID { get; set; }
        public int AccountChannelID { get; set; }
        public string OTPCode { get; set; }
        public int SmsSequence { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string LocalIP { get; set; }
        public string AccountIP { get; set; }
        public int? OriginalOTPID { get; set; }
        public int StatusID { get; set; }
        public virtual AccountChannel AccountChannel { get; set; }
    }
}
