using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntitiesConfigurations
{
    public class AccountChannelConfiguration : IEntityTypeConfiguration<AccountChannel>
    {
        public void Configure(EntityTypeBuilder<AccountChannel> builder)
        {
            builder.HasKey(s => s.ID);
            builder.HasOne(s => s.Channel).WithMany(s => s.AccountChannels).HasForeignKey(s => s.ChannelID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(s => s.Account).WithMany(s => s.AccountChannels).HasForeignKey(s => s.AccountID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
