using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public static class Constants
    {
        public static class AvaliableRoles
        {
            public const string SuperAdmin = "SuperAdmin";
            public const string Admin = "Admin";
            public const string Manager = "Manager";
            public const string Consumer = "Consumer";
            public const string AccountAdmin = "AccountAdmin";
        }

        public static class AvaliableClaims
        {
            public const string DoTransaction = "DoTransaction";
            public const string SalesReports = "SalesReports";
            public const string TransactionReports = "TransactionReports";
            public const string FinantialReports = "FinantialReports";
        }
        public static class AvaliableClaimValues
        {
            public const string True = "1";
            public const string False = "0";
        }
    }
}
