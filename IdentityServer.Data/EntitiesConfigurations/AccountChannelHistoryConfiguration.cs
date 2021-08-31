using IdentityServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Data.EntitiesConfigurations
{
   public class AccountChannelHistoryConfiguration : IEntityTypeConfiguration<AccountChannelHistory>
    {
        public void Configure(EntityTypeBuilder<AccountChannelHistory> builder)
        {
            builder.HasKey(s => s.ID);
            builder.HasOne(s => s.Channel).WithMany(s => s.AccountChannelHistories).HasForeignKey(s => s.ChannelID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(s => s.Account).WithMany(s => s.AccountChannelHistories).HasForeignKey(s => s.AccountID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
