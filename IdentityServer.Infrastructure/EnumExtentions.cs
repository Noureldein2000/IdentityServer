using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Infrastructure
{
    public class EnumExtentions
    {
    }

    public enum ActiveStatus : short
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
    public enum UserTypeStatus : short // to check if user related to account or employee
    {
        AccountUser = 1,
        Employee = 2

    }

    public enum AccountRequestStatus : short
    {
        UnderProcessing = 1,
        Approved = 2,
        Rejected = 3,
    }
    public enum Roles : short
    {
        SuperAdmin = 1,
        Admin = 2,
        Manager = 3,
        Sales = 4,
        Consumer = 5,
        AccountAdmin = 6
    }

    public enum Modules : short
    {
        Account = 1,
        Services = 2,
        Transaction = 3
    }
    public enum AccountChannelStatus : short
    {
        Inactive = 0,
        Active = 1,
        Created = 2,
        Suspend = 3,
        Deleted = 4
    }
}
