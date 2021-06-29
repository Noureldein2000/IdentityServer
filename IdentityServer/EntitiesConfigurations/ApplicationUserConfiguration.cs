using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntitiesConfigurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasIndex(s => s.NormalizedUserName).IsUnique(false);
            builder.HasIndex(s => s.NormalizedEmail).IsUnique(false);
            builder.HasIndex(s => new { s.UserName, s.ReferenceID }).IsUnique(true);
        }
    }
}
