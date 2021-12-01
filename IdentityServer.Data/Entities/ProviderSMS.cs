using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Data.Entities
{
    public class ProviderSMS : BaseEntity<int>
    {
        public string URL { get; set; }
        public int TimeOut { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string SenderName { get; set; }
        public int ProviderID { get; set; }
        public bool Status { get; set; }
        public virtual ProviderSMSParams ProviderSMSParams{ get; set; }
    }
}
