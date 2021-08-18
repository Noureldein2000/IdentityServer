using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class AddAccountChannelTypeModel
    {
        [Required]
        public int AccountID { get; set; }
        [Required]
        public int ChannelTypeID { get; set; }
        public bool HasLimitedAccess { get; set; }
        [Required]
        public int ExpirationPeriod { get; set; }
    }
}
