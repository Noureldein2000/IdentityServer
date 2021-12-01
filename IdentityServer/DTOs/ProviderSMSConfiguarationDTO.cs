using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.DTOs
{
    public class ProviderSMSConfiguarationDTO
    {
        public SwitchEndPointDTO switchEndPointDTO { get; set; }
        public ProviderSMSDTO providerSMSDTO{ get; set; }
    }
}
