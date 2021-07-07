using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Data.Seeding
{
    public static class Permissions
    {
        public static List<string> GetPermisions(string module)
        {
            return new List<string>
            {
                $"Permission.{module}.View",
                $"Permission.{module}.Create",
                $"Permission.{module}.Update",
                $"Permission.{module}.Delete",
            };
        }
    }
}
