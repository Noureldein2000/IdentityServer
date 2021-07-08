using IdentityServer.Data.Entities;
using IdentityServer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data.EntitiesConfigurations
{
    public class AccountRequestConfiguration : IEntityTypeConfiguration<AccountRequest>
    {
        public void Configure(EntityTypeBuilder<AccountRequest> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(s => s.Email).HasMaxLength(255);
            builder.Property(s => s.Address).HasMaxLength(255).IsRequired();
            builder.Property(s => s.Mobile).HasMaxLength(15).IsRequired(); 
            builder.Property(s => s.NationalID).HasMaxLength(255).IsRequired();
            builder.Property(s => s.AccountName).HasMaxLength(255).IsRequired();
            builder.Property(s => s.OwnerName).HasMaxLength(255).IsRequired();
            builder.Property(s => s.CommercialRegistrationNo).HasMaxLength(50).IsRequired();
            builder.Property(s => s.TaxNo).HasMaxLength(50).IsRequired();
            builder.Property(s => s.AccountRequestStatus).HasDefaultValue(AccountRequestStatus.UnderProcessing).IsRequired();

            builder.HasOne(s => s.Activity).WithMany(s => s.AccountRequests).HasForeignKey(s => s.ActivityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Region).WithMany(a => a.AccountRequests).HasForeignKey(a => a.RegionID)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(s => s.Mobile).IsUnique();
        }
    }
}
