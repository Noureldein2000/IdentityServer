using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class AccountTypeProfile : BaseEntity<int>
    {
        public int AccountTypeID { get; set; }
        public int ProfileID { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
