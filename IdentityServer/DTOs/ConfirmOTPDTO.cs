using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.DTOs
{
    public class ConfirmOTPDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountId { get; set; }
        public string ChannelType { get; set; }
        public string ChannelId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string OTP { get; set; }
        public string Id { get; set; }
    }
}
