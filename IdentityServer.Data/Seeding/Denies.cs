using IdentityServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Data.Seeding
{
    public static class Denies
    {
        public static IEnumerable<string> GenerateDeniesList(string module)
        {
            return new List<string>()
            {
                $"Deny.{module}.View",
                $"Deny.{module}.Create",
                $"Deny.{module}.Edit",
                $"Deny.{module}.Delete",
                $"Deny.{module}.Do",
            };
        }
        public static IEnumerable<string> GenerateAllDenies()
        {
            var allPermissions = new List<string>();
            var modules = Enum.GetValues(typeof(Modules));
            foreach (var module in modules)
            {
                allPermissions.AddRange(GenerateDeniesList(module.ToString()));
            }
            return allPermissions;
        }
    }
}
