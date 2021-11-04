using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class ConfirmOTPModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string AccountId { get; set; }
        public string ChannelType { get; set; } //??
        [Required]
        public string ChannelId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        [Required]
        public string OTP { get; set; }
        [Required]
        public string Id { get; set; }
    }
}
