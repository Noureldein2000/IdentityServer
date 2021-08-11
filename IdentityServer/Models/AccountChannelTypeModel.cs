using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class AccountChannelTypeModel
    {
        public int Id { get; set; }
        public int AccountID { get; set; }
        public int ChannelTypeID { get; set; }
        public string ChannelTypeName { get; set; }
        public bool HasLimitedAccess { get; set; }
        public int ExpirationPeriod { get; set; }
    }
}
