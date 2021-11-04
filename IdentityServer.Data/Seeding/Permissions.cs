using IdentityServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Data.Seeding
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsList(string module)
        {
            return new List<string>
            {
                $"Permission.{module}.View",
                $"Permission.{module}.Create",
                $"Permission.{module}.Edit",
                $"Permission.{module}.Delete",
                $"Permission.{module}.Do",
            };
        }
        public static IEnumerable<string> GenerateAllPermissions()
        {
            var allPermissions = new List<string>();
            var modules = Enum.GetValues(typeof(Modules));
            foreach (var module in modules)
            {
                allPermissions.AddRange(GeneratePermissionsList(module.ToString()));
            }
            return allPermissions;
        }
    }
}
