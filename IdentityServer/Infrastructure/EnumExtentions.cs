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
    public enum UserTypeStatus // to check if user related to account or employee
    {
        AccountUser = 1,
        Employee = 2
        
    }

    public enum AccountRequestStatus
    {
        UnderProcessing=1,
        Approved = 2,
        Rejected = 3,
    }
}
