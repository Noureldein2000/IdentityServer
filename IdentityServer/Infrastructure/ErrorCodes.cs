using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Infrastructure
{
    public static class ErrorCodes
    {
        public static string Unknown = "Unknown";
        public static class Autorization
        {
            public static string MustInputOTP = "209";
            public static string MustChangePassword = "-8";
            public static string NoAuth = "0";
        }
    }
}
