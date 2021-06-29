using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntitiesConfigurations
{
    public class AccountOwnerConfiguration : IEntityTypeConfiguration<AccountOwner>
    {
        public void Configure(EntityTypeBuilder<AccountOwner> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(s => s.Email).HasColumnType("nvarchar(255)");
            builder.Property(s => s.Address).HasColumnType("nvarchar(255)");
            builder.Property(s => s.Mobile).HasColumnType("nvarchar(15)");
            builder.Property(s => s.NationalID).HasColumnType("nvarchar(255)");
            builder.Property(s => s.Name).HasColumnType("nvarchar(255)");
            builder.HasOne(s => s.Account).WithOne(s => s.AccountOwner).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
