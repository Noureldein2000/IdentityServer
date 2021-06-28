using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntitiesConfigurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(s => s.Name);
            builder.HasMany(s => s.ApplicationUsers).WithOne(s => s.UserType).HasForeignKey(s => s.UserTypeID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
