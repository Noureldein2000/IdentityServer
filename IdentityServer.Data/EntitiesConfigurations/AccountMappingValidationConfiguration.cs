using IdentityServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Data.EntitiesConfigurations
{
    public class AccountMappingValidationConfiguration : IEntityTypeConfiguration<AccountMappingValidation>
    {
        public void Configure(EntityTypeBuilder<AccountMappingValidation> builder)
        {
            builder.HasKey(a => a.ID);

            builder.HasOne(a => a.ChildAccountType).WithMany(a => a.AccountMappingValidations).HasForeignKey(a => a.ChildID)
               .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(a => a.ParentAccountType).WithMany(a => a.AccountMappingValidations).HasForeignKey(a => a.ParentID)
            //  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
