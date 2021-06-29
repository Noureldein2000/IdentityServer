using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntitiesConfigurations
{
    public class AccountRequestConfiguration : IEntityTypeConfiguration<AccountRequest>
    {
        public void Configure(EntityTypeBuilder<AccountRequest> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(s => s.Email).HasMaxLength(255);
            builder.Property(s => s.Address).HasMaxLength(255);
            builder.Property(s => s.Mobile).HasMaxLength(15);
            builder.Property(s => s.NationalID).HasMaxLength(255);
            builder.Property(s => s.AccountName).HasMaxLength(255);
            builder.Property(s => s.OwnerName).HasMaxLength(255);
            builder.Property(s => s.CommercialRegistrationNo).HasMaxLength(50);
            builder.Property(s => s.TaxNo).HasMaxLength(50);
            builder.HasOne(s => s.Activity).WithMany(s => s.AccountRequests).HasForeignKey(s => s.ActivityID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
