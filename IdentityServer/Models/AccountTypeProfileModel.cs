using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class AccountTypeProfileModel
    {
        public int Id { get; set; }
        public int AccountTypeID { get; set; }
        public int ProfileID { get; set; }
        public string Profile { get; set; }
        public string AccountType { get; set; }
        public string FullName { get; set; }
    }
}
