using IdentityServer.Entities;
using IdentityServer.Helpers;
using IdentityServer.Repositories.Base;
using IdentityServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ISMSService, VictorySMSService>();
            services.AddScoped<IAccountService, AccountService>();

            services.Replace(new ServiceDescriptor(
               serviceType: typeof(IPasswordHasher<ApplicationUser>),
               implementationType: typeof(MD5PasswordHasher<ApplicationUser>),
               ServiceLifetime.Scoped));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseSuccessEvents = false;
                options.Events.RaiseFailureEvents = true;
            })
              .AddInMemoryClients(Config.GetClients())
              .AddInMemoryApiResources(Config.GetApiResources())
              //.AddInMemoryApiScopes(Config.GetApiScopes())
              .AddInMemoryIdentityResources(Config.GetIdentityResources())
              //.AddCustomAuthorizeRequestValidator<CustomAuthorizeRequestValidator>()
              .AddAspNetIdentity<ApplicationUser>();

            services.AddControllers(options =>
            {
                options.EnableEndpointRouting = false;
                //options.Filters.Add(typeof(ValidateModelAttribute));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseIdentityServer();
            //app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
