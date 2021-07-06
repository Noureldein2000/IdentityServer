using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntitiesConfigurations
{
    public class GovernorateConfiguration : IEntityTypeConfiguration<Governorate>
    {
        public void Configure(EntityTypeBuilder<Governorate> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(s => s.Name).IsRequired();
            builder.HasMany(s => s.Regions).WithOne(s => s.Governorate).HasForeignKey(s => s.GovernorateID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
