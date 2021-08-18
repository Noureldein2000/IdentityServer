using IdentityServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Data.EntitiesConfigurations
{
    public class AccountRelationMappingConfiguration : IEntityTypeConfiguration<AccountRelationMapping>
    {
        public void Configure(EntityTypeBuilder<AccountRelationMapping> builder)
        {
            builder.HasKey(a => a.ID);

            builder.HasOne(a => a.Account).WithMany(a => a.AccountRelationMappings).HasForeignKey(a => a.AccountID)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
