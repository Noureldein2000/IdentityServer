using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.DTOs
{
    public class AccountChannelDTO
    {
        public string? AccountId { get; set; }
        public string? ChannelId { get; set; } //emi or ip
        //public int ChannelTypeId { get; set; }
        public string ChannelCategory{ get; set; }
        public DateTime LocalDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ChannelType { get; set; }
        public string LocalIP { get; set; }
        public string AccountIP { get; set; }
    }
}
