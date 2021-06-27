using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntitiesConfigurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.ID);

            builder.HasOne(a => a.AccountType).WithMany(a => a.Accounts)
                .HasForeignKey(a => a.AccountTypeID).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
