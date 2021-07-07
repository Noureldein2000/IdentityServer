using IdentityServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data.EntitiesConfigurations
{
    public class AccountOwnerConfiguration : IEntityTypeConfiguration<AccountOwner>
    {
        public void Configure(EntityTypeBuilder<AccountOwner> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(s => s.Email).HasMaxLength(255);
            builder.Property(s => s.Address).HasMaxLength(255);
            builder.Property(s => s.Mobile).HasMaxLength(15);
            builder.Property(s => s.NationalID).HasMaxLength(255);
            builder.Property(s => s.Name).HasMaxLength(255);
            builder.HasOne(s => s.Account).WithOne(s => s.AccountOwner).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
