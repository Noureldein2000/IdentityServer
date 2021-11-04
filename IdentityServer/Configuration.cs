using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
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
                new ApiScope("SOF")
            };

        public static IEnumerable<Client> GetClients() =>
            new List<Client> {
                new Client
            {
                ClientId = "admin_dashboard_123",
                ClientName = "Admin Dashboard",
                ClientSecrets = {new Secret("d5a9b78e-a694-4026-af7f-6d559d8a3949".ToSha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RedirectUris = { "https://localhost:44328/signin-oidc" },
                //FrontChannelLogoutUri = "https://localhost:44328/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:44328/signout-callback-oidc" },
                AllowedScopes =
                {
                    "SOF",
                    "Auth",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "roles"
                },
                RequireConsent = false,
                AlwaysIncludeUserClaimsInIdToken = true,
                
                //AllowOfflineAccess = true 
                //puts all the claims in id_token 
                //AlwaysIncludeUserClaimsInIdToken = true
            }

        };
    }
}
