using IdentityServer.Migrations;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static IdentityServer.Models.Constants;

namespace IdentityServer.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<ChannelType> ChannelTypes { get; set; }
        public virtual DbSet<ChannelCategory> ChannelCategories { get; set; }
        public virtual DbSet<ChannelIdentifier> ChannelIdentifiers { get; set; }
        public virtual DbSet<ChannelOwner> ChannelOwners { get; set; }
        public virtual DbSet<ChannelPaymentMethod> ChannelPaymentMethods { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountChannel> AccountChannels { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<AccountChannelType> AccountChannelTypes { get; set; }
        public virtual DbSet<AccountProfile> AccountProfiles { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<OTP> OTPs { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
        .Entries()
        .Where(e => e.Entity is BaseEntity<int> && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity<int>)entityEntry.Entity).UpdateDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity<int>)entityEntry.Entity).CreationDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedData.Seed(builder);
        }
    }
}
