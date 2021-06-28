using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Infrastructure
{
    public class EnumExtentions
    {
    }

    public enum ActiveStatus
    {
        True = 1,
        False = 0
    }
    public enum ChannelCategoryStatus
    {
        Web = 1,
        API = 2,
        Mobile = 3,
        POS = 4
    }
    public enum AccountTypeStatus
    {
        Company = 11
    }
}
