﻿using IdentityServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class CreateUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int? AccountId { get; set; }
        public string Email { get; set; }
        public Roles UserRole { get; set; }
    }
}
