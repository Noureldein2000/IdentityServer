using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Data.Entities
{
    public class AccountMappingValidation : BaseEntity<int>
    {
        public int ParentID { get; set; }
        public int ChildID { get; set; }
        public AccountType ParentAccountType { get; set; }
        public AccountType ChildAccountType { get; set; }
    }
}
