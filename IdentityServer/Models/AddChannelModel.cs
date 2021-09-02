using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class AddChannelModel
    {
        public string Name { get; set; }
        public int ChannelTypeID { get; set; }
        public int ChannelOwnerID { get; set; }
        public string Serial { get; set; }
        public int PaymentMethodID { get; set; }
        public string Value { get; set; }
        public bool Status { get; set; }
        public int CreatedBy { get; set; }
        public int? AccountId { get; set; }
    }
}
