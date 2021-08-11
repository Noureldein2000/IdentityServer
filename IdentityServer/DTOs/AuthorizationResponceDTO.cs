using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.DTOs
{
    public class AuthorizationResponceDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public int AccountId { get; set; }
        public DateTime LocalDate { get; set; }
        public DateTime ServerDate { get; set; }
        public string AccountName { get; set; }
        public int AccountType { get; set; }
        public string ServiceListVersion { get; set; }
        public string Version { get; set; }
        public int ExpirationPeriod { get; set; }
        public string Token { get; set; }
        public string[] Permissions { get; set; }
    }
}
