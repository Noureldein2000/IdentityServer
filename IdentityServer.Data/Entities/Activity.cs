using System.Collections.Generic;

namespace IdentityServer.Data.Entities
{
    public class Activity : BaseEntity<int>
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public virtual ICollection<AccountRequest> AccountRequests { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
