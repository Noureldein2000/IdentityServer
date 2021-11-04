using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class EditAccountChannelTypeModel
    {
        public int Id { get; set; }
        public bool HasLimitedAccess { get; set; }
        public int ExpirationPeriod { get; set; }
    }
}
