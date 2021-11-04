using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class RegionModel
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int GovernorateID{ get; set; }
    }
}
