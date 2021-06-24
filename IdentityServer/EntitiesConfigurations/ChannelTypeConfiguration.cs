using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntitiesConfigurations
{
    public class ChannelTypeConfiguration : IEntityTypeConfiguration<ChannelType>
    {
        public void Configure(EntityTypeBuilder<ChannelType> builder)
        {
            builder.HasKey(c=>c.ID);
            builder.Property(c=>c.Name).IsRequired();
            builder.Property(c=>c.ArName).IsRequired();
            builder.Property(c=>c.ChannelCategoryID).IsRequired();

            builder.HasOne<ChannelCategory>(c => c.ChannelCategory)
                .WithMany(cc => cc.ChannelTypes).HasForeignKey(c=>c.ChannelCategoryID);
        }
    }
}
