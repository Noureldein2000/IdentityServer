using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntitiesConfigurations
{
    public class ChannelConfiguration : IEntityTypeConfiguration<Channel>
    {
        public void Configure(EntityTypeBuilder<Channel> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(s => s.Name).IsRequired();
            builder.HasOne(s => s.ChannelType).WithMany(s => s.Channels)
                .HasForeignKey(s => s.ChannelTypeID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(s => s.ChannelOwner).WithMany(s => s.Channels)
                .HasForeignKey(s => s.ChannelOwnerID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(s => s.ChannelPaymentMethod).WithMany(s => s.Channels)
                .HasForeignKey(s => s.PaymentMethodID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
