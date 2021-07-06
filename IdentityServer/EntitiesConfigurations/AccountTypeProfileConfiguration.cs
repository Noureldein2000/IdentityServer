using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntitiesConfigurations
{
    public class AccountTypeProfileConfiguration : IEntityTypeConfiguration<AccountTypeProfile>
    {
        public void Configure(EntityTypeBuilder<AccountTypeProfile> builder)
        {
            builder.HasKey(ap => ap.ID);

            builder.HasOne(ap => ap.Profile).WithMany(ap => ap.AccountTypeProfiles)
                .HasForeignKey(ap => ap.ProfileID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ap => ap.AccountType).WithMany(ap => ap.AccountTypeProfiles)
                .HasForeignKey(ap => ap.AccountTypeID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
