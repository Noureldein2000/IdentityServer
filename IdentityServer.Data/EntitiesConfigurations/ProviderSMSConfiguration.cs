using IdentityServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Data.EntitiesConfigurations
{
    public class ProviderSMSConfiguration : IEntityTypeConfiguration<ProviderSMS>
    {
        public void Configure(EntityTypeBuilder<ProviderSMS> builder)
        {
            builder.HasKey(s => s.ID);
            builder.HasOne(s => s.ProviderSMSParams).WithOne(s => s.ProviderSMS).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
