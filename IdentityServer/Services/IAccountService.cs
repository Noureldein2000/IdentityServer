using IdentityServer.DTOs;
using IdentityServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface IAccountService
    {
        AddRequestDTO AddRequest(AddRequestDTO addRequestDTO);
    }
}
