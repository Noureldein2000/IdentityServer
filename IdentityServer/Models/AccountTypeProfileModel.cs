﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class AccountTypeProfileModel
    {
        public int Id { get; set; }
        public int AccountTypeID { get; set; }
        public string AccountTypeName { get; set; }
        public int ProfileID { get; set; }
        public string ProfileName { get; set; }
    }
}
