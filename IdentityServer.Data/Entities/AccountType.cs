using IdentityServer.Infrastructure;
using System.Collections.Generic;

namespace IdentityServer.Data.Entities
{
    public class AccountType:BaseEntity<int>
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public ActiveStatus Status { get; set; }
        public int? TreeLevel { get; set; }

        public virtual ICollection<AccountTypeProfile> AccountTypeProfiles { get; set; }
        public virtual ICollection<AccountMappingValidation> AccountMappingValidations { get; set; }
        
    }
}
