using IdentityServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data.EntitiesConfigurations
{
    public class OTPConfiguration : IEntityTypeConfiguration<OTP>
    {
        public void Configure(EntityTypeBuilder<OTP> builder)
        {
            builder.HasKey(s => s.ID);
            builder.HasOne(s => s.AccountChannel).WithMany(s => s.OTPs).HasForeignKey(s => s.AccountChannelID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
