using System.Collections.Generic;

namespace IdentityServer.Data.Entities
{
    public class AccountTypeProfile : BaseEntity<int>
    {
        public int AccountTypeID { get; set; }
        public int ProfileID { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
