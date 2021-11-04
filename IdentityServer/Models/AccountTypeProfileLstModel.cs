using IdentityServer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class AccountTypeProfileLstModel
    {
        public List<ProfileDTO> LstProfile { get; set; }
        public List<AccountTypeDTO> LstAccountType { get; set; }
    }
}
