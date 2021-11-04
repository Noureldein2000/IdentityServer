using IdentityServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class CreateUserModel
    {
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int? AccountId { get; set; }
        public string Email { get; set; }
        [Required]
        public Roles UserRole { get; set; }
    }
}
