using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Infrastructure
{
    public static class ErrorCodes
    {
        public static string Unknown = "Unknown";
        public static string Success = "200";
        public static string FailedTry = "-3";
        public static class Autorization
        {
            public static string MustInputOTP = "209";
            public static string MustChangePassword = "-8";
            public static string NoAuth = "0";
        }
        public static class ChangePassword
        {
            public static string CannotChangeOldPassword = "-22";
            public static string InvalidPassword = "-23";
        }
        public static class OTP
        {
            public static string InvalidOTP = "-25";
        }
    }
}
