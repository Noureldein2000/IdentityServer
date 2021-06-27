using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntitiesConfigurations
{
    public class ChannelIdentifierConfiguration : IEntityTypeConfiguration<ChannelIdentifier>
    {
        public void Configure(EntityTypeBuilder<ChannelIdentifier> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(s => s.Value).IsRequired();
            builder.Property(s => s.Status).IsRequired();
            builder.HasOne(s => s.Channel).WithMany(s => s.ChannelIdentifiers)
                .HasForeignKey(s => s.ChannelID).OnDelete(DeleteBehavior.NoAction);
            builder.Property(s => s.UpdatedBy);
        }
    }
}
