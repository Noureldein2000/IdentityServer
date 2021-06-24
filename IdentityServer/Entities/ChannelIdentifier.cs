using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class ChannelIdentifier : BaseEntity<int>
    {
        //Primary Fields
        public string Value { get; set; }
        public int Status { get; set; }
        public int ChannelID { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        //Relational Entitiy
        public Channel Channel{ get; set; }
    }
}
