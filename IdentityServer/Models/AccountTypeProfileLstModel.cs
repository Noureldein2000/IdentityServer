using IdentityServer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class AccountTypeProfileLstModel
    {
        public List<ProfileDTO> lstProfile { get; set; }
        public List<AccountTypeDTO> lstAccountType { get; set; }
    }
}
