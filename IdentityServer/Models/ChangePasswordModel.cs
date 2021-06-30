using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class ChangePasswordModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int AccountId { get; set; }
        public int ChannelType { get; set; }
        public string ChannelId { get; set; }
        public string NewPassword { get; set; }
        public string Language { get; set; }
    }
}
