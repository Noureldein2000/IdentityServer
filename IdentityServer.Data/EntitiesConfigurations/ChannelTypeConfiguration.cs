using IdentityServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data.EntitiesConfigurations
{
    public class ChannelTypeConfiguration : IEntityTypeConfiguration<ChannelType>
    {
        public void Configure(EntityTypeBuilder<ChannelType> builder)
        {
            builder.HasKey(c=>c.ID);
            builder.Property(c=>c.Name).IsRequired();
            builder.Property(c=>c.ArName).IsRequired();
            builder.Property(c=>c.ChannelCategoryID).IsRequired();

            builder.HasOne(c => c.ChannelCategory)
                .WithMany(c => c.ChannelTypes).HasForeignKey(c=>c.ChannelCategoryID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
