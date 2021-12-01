using IdentityServer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface ISMSService
    {
        string SendMessage(string body, string receiver);
        string SendMessage(string body,string language, string receiver);
        ProviderSMSConfiguarationDTO GetProviderSMSConfiguaration();
    }
}
