using IdentityServer.Data.Entities;
using IdentityServer.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Data.Seeding
{
    public static class DefaultUsers
    {
        public static async Task SeedSuperAdminUsersAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminUser = new ApplicationUser
            {
                Id = "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                Email = "admin@momkn.org",
                EmailConfirmed = true,
                PhoneNumber = "012111111111",
                UserName = "momknAdmin",
                NormalizedEmail = "admin@momkn.org".ToUpper(),
                NormalizedUserName = "superadmin".ToUpper(),
                LockoutEnabled = true
            };
            var user = await userManager.FindByNameAsync(adminUser.UserName);
            if (user == null)
            {
                await userManager.CreateAsync(adminUser, "P@$$w0rd");
                //var hashedPassword = userManager.PasswordHasher.HashPassword(adminUser, "P@$$w0rd123");
                //adminUser.PasswordHash = hashedPassword;
                await userManager.AddToRolesAsync(adminUser, new List<string> {
                    Roles.SuperAdmin.ToString()
                });
            }
            await roleManager.SeedClaimsForSuperAdmin();
        }
        public static async Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());
            await roleManager.AddPermissionsClaims(adminRole, Modules.Account.ToString()); // Permission.Account.View
        }

        public static async Task AddPermissionsClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var claims = await roleManager.GetClaimsAsync(role);
            var newClaims = Permissions.GeneratePermissionsList(module);
            foreach (var claim in newClaims)
            {
                if (!claims.Any(c => c.Type == "Permission" && c.Value == claim))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", claim));
                }
            }

        }
    }
}
