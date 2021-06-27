using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntitiesConfigurations
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(s => s.Token).IsRequired();
            builder.HasOne(s => s.User).WithMany(s => s.UserTokens).HasForeignKey(s => s.UserID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
