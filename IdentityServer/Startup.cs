using IdentityServer.Data;
using IdentityServer.Data.Entities;
using IdentityServer.Helpers;
using IdentityServer.Repositories.Base;
using IdentityServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Globalization;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
          
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

           

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.MaxAge = TimeSpan.FromDays(1);
                config.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Unspecified;
                config.Cookie.Name = "Cookies";
                config.LoginPath = "/Auth/Login";
            });

            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })

               .AddInMemoryApiResources(IdentityServer.Configuration.GetApiResources())
               .AddInMemoryIdentityResources(IdentityServer.Configuration.GetIdentityResources())
               //.AddInMemoryApiScopes(Config.GetApiScopes())
               .AddInMemoryClients(IdentityServer.Configuration.GetClients(Configuration))
               .AddAspNetIdentity<ApplicationUser>()
               .AddDeveloperSigningCredential();
             //.AddCustomAuthorizeRequestValidator<CustomAuthorizeRequestValidator>()
             //.AddDeveloperSigningCredential();

            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
  
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountTypeProfileService, AccountTypeProfileService>();
            services.AddScoped<IChannelService, ChannelService>();
            services.AddScoped<ISMSService, VictorySMSService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<IEntityService, EntityService>();
            services.AddScoped<IChannelTypeService, ChannelTypeService>();
            services.AddScoped<IChannelOwnerService, ChannelOwnerService>();
            services.AddScoped<IChannelPaymentMethodService, ChannelPaymentMethodService>();
            services.AddScoped<IChannelCategoryService, ChannelCategoryService>();

            //services.Replace(new ServiceDescriptor(
            //   serviceType: typeof(IPasswordHasher<ApplicationUser>),
            //   implementationType: typeof(MD5PasswordHasher<ApplicationUser>),
            //   ServiceLifetime.Scoped));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                //c.DocumentFilter<SwaggerAddEnumDescriptions>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });//.AddSwaggerGenNewtonsoftSupport();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedLanguages = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("ar")
                };
                options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
                options.SupportedCultures = supportedLanguages;
                options.SupportedUICultures = supportedLanguages;
            });
                

            services.AddControllersWithViews().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                )
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1");
            });
            app.UseRouting();
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseIdentityServer();
            app.UseAuthorization();
            //app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            //app.UseAuthorization();
        
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapDefaultControllerRoute();
            //});
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapAreaControllerRoute(
                //     name: "areaRoute",
                //     areaName: "SuperAdmin",
                //     pattern: "{area:exists}/{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=Login}/{id?}");
            });
        }
    }
}
