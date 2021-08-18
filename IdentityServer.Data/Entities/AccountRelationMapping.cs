using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Data.Entities
{
    public class AccountRelationMapping : BaseEntity<int>
    {
        public int AccountID { get; set; }
        public int? ParentID { get; set; }
        public virtual Account Account { get; set; }
    }
}
