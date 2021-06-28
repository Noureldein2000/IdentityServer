using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.DTOs
{
    public class AccountChannelDTO
    {
        public int AccountId { get; set; }
        public string ChannelId { get; set; } //emi or ip
        public int ChannelTypeId { get; set; }
        public bool MustChangePassword { get; set; }
        public int ChannelCategory{ get; set; }
        public int UserId { get; set; }
        public string AccountIP { get; set; }
        public DateTime LocalDate { get; set; }
        public string LocalIP { get; set; }
    }
}
