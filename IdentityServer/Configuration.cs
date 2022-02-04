using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Configuration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
           new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                 new IdentityResource
                {
                    Name = "roles",
                    DisplayName = "Roles",
                    Description = "Allow the service access to your user roles.",
                    UserClaims = new[] { JwtClaimTypes.Role, ClaimTypes.Role },
                    ShowInDiscoveryDocument = true,
                    Required = true,
                    Emphasize = true
                },
                new IdentityResource
                {
                    Name = "SOF"
                },
                new IdentityResource
                {
                    Name = "Auth"
                },
                new IdentityResource
                {
                    Name = "TMS"
                }
           };

        public static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource> {
                new ApiResource("SOF"), //it means only role.ebram claim type can access ApiOne
                 new ApiResource("Auth"),
                 new ApiResource("roles"),
            };

        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope> {
                new ApiScope("SOF", "Source of fund"),
                new ApiScope("TMS", "Transactions management system")
            };

        public static IEnumerable<Client> GetClients(IConfiguration configuration) =>
            new List<Client> {
                new Client
                {
                    ClientId = "admin_dashboard_123",
                    ClientName = "Admin Dashboard",
                    ClientSecrets = {new Secret("d5a9b78e-a694-4026-af7f-6d559d8a3949".ToSha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    ClientUri = $"{configuration.GetValue<string>("IdentityServer:RedirectApi")}",
                    RedirectUris = { $"{configuration.GetValue<string>("IdentityServer:RedirectApi")}/signin-oidc" },
                    //FrontChannelLogoutUri = $"{configuration.GetValue<string>("IdentityServer:RedirectApi")}/signout-oidc",
                    //PostLogoutRedirectUris = { $"{configuration.GetValue<string>("IdentityServer:RedirectApi")}/signout-callback-oidc" },
                    PostLogoutRedirectUris = { $"{configuration.GetValue<string>("IdentityServer:RedirectApi")}/Home/Index" },
                    AllowedCorsOrigins = {configuration.GetValue<string>("IdentityServer:RedirectApi")},
                    AllowedScopes =
                    {
                        "SOF",
                        "Auth",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "TMS"
                    },
                    RequireConsent = false,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowRememberConsent = false
                    //AllowOfflineAccess = true
                },
                new Client
                {
                    ClientId = "tms_123",
                    ClientName = "TMS",
                    ClientSecrets = {new Secret("d5a9b78e-a694-4026-af7f-6d559d8a3949".ToSha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedCorsOrigins = {configuration.GetValue<string>("IdentityServer:TMS") },
                    AllowedScopes =
                    {
                        "SOF",
                        "Auth",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "TMS"
                    }
                }

        };
    }
}
