using IdentityServer.Data;
using IdentityServer.Data.Entities;
using IdentityServer.Data.Seeding;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var environment = services.GetRequiredService<IWebHostEnvironment>();
                if (environment.IsDevelopment())
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.Migrate();
                }
                //    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                //    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                //    await DefaultRoles.SeedAsync(roleManager);
                //    await DefaultUsers.SeedSuperAdminAsync(userManager, roleManager);
            }
            catch (Exception)
            {

                throw;
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
