using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class EditChannelModel
    {
        public int ChannelId { get; set; }
        public string Name { get; set; }
        public int ChannelTypeID { get; set; }
        public int ChannelOwnerID { get; set; }
        public string Serial { get; set; }
        public int PaymentMethodID { get; set; }
        public string Value { get; set; }
        public bool Status { get; set; }
        public int UpdatedBy { get; set; }
    }
}
