using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.DTOs
{
    public class ChannelDTO
    {
        public int ChannelID { get; set; }
        public int? AccountChannelID { get; set; }
        public string Name { get; set; }
        public int ChannelTypeID { get; set; }
        public string ChannelTypeName { get; set; }
        public int ChannelOwnerID { get; set; }
        public string ChannelOwnerName { get; set; }
        public string Serial { get; set; }
        public int PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; }
        public string Value { get; set; }
        public bool? Status { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? AccountId { get; set; }
        public DateTime CreationDate{ get; set; }
    }
}
