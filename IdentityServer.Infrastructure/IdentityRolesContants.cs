using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Infrastructure
{
    public class IdentityRolesContants
    {
    }

    public enum Roles : short
    {
        SuperAdmin = 1,
        Admin = 2,
        Manager = 3,
        Consumer = 4
    }
}
