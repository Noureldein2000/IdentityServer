using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Data.Entities
{
   public class DemonationEntity :BaseEntity<int>
    {
        public int DemonationID { get; set; }
        public int EntityID { get; set; }
    }
}
