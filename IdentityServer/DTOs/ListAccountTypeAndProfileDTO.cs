using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.DTOs
{
    public class ListAccountTypeAndProfileDTO
    {
        public ListAccountTypeAndProfileDTO()
        {
            LstAccountType = new List<AccountTypeDTO>();
            LstProfile = new List<ProfileDTO>();
        }
        public List<ProfileDTO> LstProfile { get; set; }
        public List<AccountTypeDTO> LstAccountType { get; set; }
    }
}
