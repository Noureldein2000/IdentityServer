using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.DTOs
{
    public class ProviderSMSDTO
    {
        public string AccountId { get; set; }
        public string Password { get; set; }
        public string Secretkey { get; set; }
        public string SenderName { get; set; }
        public string SMSText { get; set; }
        public string ReceiverMSISDN { get; set; }
        public string ProviderID { get; set; }
    }
}
