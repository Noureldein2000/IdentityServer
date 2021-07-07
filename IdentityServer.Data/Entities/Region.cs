using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data.Entities
{
    public class Region : BaseEntity<int>
    {
        public string Name { get; set; }
        public int GovernorateID { get; set; }
        public virtual Governorate Governorate { get; set; }
        public virtual ICollection<AccountRequest> AccountRequests { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
