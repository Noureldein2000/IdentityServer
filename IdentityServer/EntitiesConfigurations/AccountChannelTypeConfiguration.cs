using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntitiesConfigurations
{
    public class AccountChannelTypeConfiguration : IEntityTypeConfiguration<AccountChannelType>
    {
              public void Configure(EntityTypeBuilder<AccountChannelType> builder)
        {
            builder.HasKey(x=>x.ID);
            builder.Property(x=>x.AccountID).IsRequired();
            builder.Property(x=>x.ChannelTypeID).IsRequired();
            builder.Property(x=>x.HasLimitedAccess).IsRequired();
            builder.Property(x=>x.ExpirationPeriod).IsRequired();

            builder.HasOne(s=>s.ChannelType).WithMany(s=>s.AccountChannelTypes)
                .HasForeignKey(s=>s.ChannelTypeID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
