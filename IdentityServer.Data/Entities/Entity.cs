using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Data.Entities
{
    public class Entity : BaseEntity<int>
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public virtual List<Account> Accounts { get; set; }
    }
}
