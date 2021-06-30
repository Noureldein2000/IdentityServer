using IdentityServer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer.Models.Constants;

namespace IdentityServer.Migrations
{
    public class SeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<UserType>().HasData(
                new UserType
                {
                    ID = 1,
                    Name = "AccountUser",
                    CreationDate = DateTime.Now
                });

            builder.Entity<Activity>().HasData(
                new Activity
                {
                    ID = 1,
                    Name = "SuperMarket",
                    NameAr = "سوبرماركت",
                    CreationDate = DateTime.Now
                });

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = AvaliableRoles.SuperAdmin,
                    NormalizedName = AvaliableRoles.SuperAdmin.ToUpper(),
                    Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf1",
                    ConcurrencyStamp = "341743f0-asd2–42de-afbf-59kmkkmk72cf1"
                },
                new IdentityRole
                {
                    Name = AvaliableRoles.Admin,
                    NormalizedName = AvaliableRoles.Admin.ToUpper(),
                    Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                    ConcurrencyStamp = "341743f0-asd2–42de-afbf-59kmkkmk72cf6"
                },
                new IdentityRole
                {
                    Name = AvaliableRoles.Manager,
                    NormalizedName = AvaliableRoles.Manager.ToUpper(),
                    Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf5",
                    ConcurrencyStamp = "341743f0-asd2–42de-afbf-59kmkkmk72cf5"
                },
                new IdentityRole
                {
                    Name = AvaliableRoles.Consumer,
                    NormalizedName = AvaliableRoles.Consumer.ToUpper(),
                    Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf4",
                    ConcurrencyStamp = "341743f0-asd2–42de-afbf-59kmkkmk72cf4"
                },
                new IdentityRole
                {
                    Name = AvaliableRoles.AccountAdmin,
                    NormalizedName = AvaliableRoles.AccountAdmin.ToUpper(),
                    Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf3",
                    ConcurrencyStamp = "341743f0-asd2–42de-afbf-59kmkkmk72cf3"
                });


            var consumerUser = new ApplicationUser
            {
                Id = "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                Email = "consumer@consumer.com",
                EmailConfirmed = true,
                PhoneNumber = "01201371236",
                UserName = "consumer",
                NormalizedEmail = "consumer@consumer.com".ToUpper(),
                NormalizedUserName = "consumer".ToUpper(),
                LockoutEnabled = true
            };
            var adminUser = new ApplicationUser
            {
                Id = "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                PhoneNumber = "012111111111",
                UserName = "admin",
                NormalizedEmail = "admin@admin.com".ToUpper(),
                NormalizedUserName = "admin".ToUpper(),
                LockoutEnabled = true
            };
            var managerUser = new ApplicationUser
            {
                Id = "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                Email = "manager@manager.com",
                EmailConfirmed = true,
                PhoneNumber = "012222222222",
                UserName = "manager",
                NormalizedEmail = "manager@manager.com".ToUpper(),
                NormalizedUserName = "manager".ToUpper(),
                LockoutEnabled = true
            };
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = ph.HashPassword(adminUser, "P@$$w0rd");

            PasswordHasher<ApplicationUser> ph2 = new PasswordHasher<ApplicationUser>();
            managerUser.PasswordHash = ph2.HashPassword(managerUser, "P@$$w0rd");

            PasswordHasher<ApplicationUser> ph3 = new PasswordHasher<ApplicationUser>();
            consumerUser.PasswordHash = ph3.HashPassword(consumerUser, "P@$$w0rd");


            builder.Entity<ApplicationUser>().HasData(
                    adminUser, managerUser, consumerUser
                );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                    UserId = "d5a9b78e-a694-4026-af7f-6d559d8a3950"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf5",
                    UserId = "d5a9b78e-a694-4026-af7f-6d559d8a3961"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf4",
                    UserId = "d5a9b78e-a694-4026-af7f-6d559d8a3949"
                });

            builder.Entity<IdentityUserClaim<string>>().HasData(
                new IdentityUserClaim<string>
                {
                    UserId = "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                    ClaimType = AvaliableClaims.DoTransaction,
                    ClaimValue = AvaliableClaimValues.True,
                    Id = 1
                },
                new IdentityUserClaim<string>
                {
                    UserId = "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                    ClaimType = AvaliableClaims.FinantialReports,
                    ClaimValue = AvaliableClaimValues.True,
                    Id = 2
                },
                new IdentityUserClaim<string>
                {
                    UserId = "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                    ClaimType = AvaliableClaims.SalesReports,
                    ClaimValue = AvaliableClaimValues.True,
                    Id = 3
                },
                 new IdentityUserClaim<string>
                 {
                     UserId = "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                     ClaimType = AvaliableClaims.TransactionReports,
                     ClaimValue = AvaliableClaimValues.True,
                     Id = 4
                 }
            );
        }
    }
}
