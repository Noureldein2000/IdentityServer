﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.DTOs
{
    public class AccountTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public bool Status { get; set; }
        public int? TreeLevel{ get; set; }
    }
}
