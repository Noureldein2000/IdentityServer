using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string AccountId { get; set; } //center_id
        public bool MustChangePassword { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
        public virtual ICollection<ChannelIdentifier> ChannelIdentifiers { get; set; }
    }
}
