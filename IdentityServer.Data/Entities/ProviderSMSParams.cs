using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Data.Entities
{
    public class ProviderSMSParams : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int ProviderSMSID { get; set; }
        public virtual ProviderSMS ProviderSMS { get; set; }
    }
}
