using Microsoft.AspNetCore.Identity;
using System;

namespace IdentityServer.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string ReferenceID { get; set; } //center_id
        public int? UserTypeID { get; set; }
        public virtual UserType UserType { get; set; }
        public bool MustChangePassword { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
