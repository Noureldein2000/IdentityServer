using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class AccountChannelHistoryModel
    {
        public string AccountName { get; set; }
        public string ChannelName { get; set; }
        public string ChannelValue { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string  Reason { get; set; }
    }
}
