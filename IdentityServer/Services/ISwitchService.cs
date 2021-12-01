using IdentityServer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
   public interface ISwitchService
    {
        string Connect<T>(T obj, SwitchEndPointDTO PSC, string BaseAddress, string TokenType);
        string Connect(SwitchEndPointDTO PSC, string BaseAddress);
    }
}
