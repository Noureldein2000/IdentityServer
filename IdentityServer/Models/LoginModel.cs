using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string? AccountId { get; set; }
        public string ChannelCategory { get; set; } //??
        public string ChannelType { get; set; } //??
        public string? ChannelId { get; set; }
        public string Version { get; set; }
        public string ServiceVersion { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Language { get; set; }

    }
}
