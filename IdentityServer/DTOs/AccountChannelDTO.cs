using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.DTOs
{
    public class AccountChannelDTO
    {
        public int Id { get; set; }
        public int AccountID { get; set; }
        public int ChannelID { get; set; }
        public string ChannelName { get; set; }
        public bool Status { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
