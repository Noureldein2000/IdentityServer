using IdentityServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data.EntitiesConfigurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.ID);

            builder.HasOne(a => a.Activity).WithMany(a => a.Accounts).HasForeignKey(a => a.ActivityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.AccountTypeProfile).WithMany(a => a.Accounts).HasForeignKey(a => a.AccountTypeProfileID)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Region).WithMany(a => a.Accounts).HasForeignKey(a => a.RegionID)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
