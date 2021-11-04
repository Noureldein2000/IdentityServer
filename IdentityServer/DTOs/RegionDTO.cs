using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.DTOs
{
    public class RegionDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GovernorateID { get; set; }
    }
}
