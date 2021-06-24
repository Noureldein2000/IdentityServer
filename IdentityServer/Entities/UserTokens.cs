﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Entities
{
    public class UserTokens : IEntityModel<int>
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string Token { get; set; }
        public bool IsValid { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
