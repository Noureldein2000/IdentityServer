using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "SOF"
                },
                new IdentityResource
                {
                    Name = "Auth"
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("SOF"),
                new ApiScope("Auth"),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("SOF"),
                new ApiResource("Auth"),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "admin_dashboard_123",
                    ClientName = "Admin Dashboard",
                    ClientSecrets = {new Secret("d5a9b78e-a694-4026-af7f-6d559d8a3949".Sha256()) },
                    RedirectUris = {"https://localhost:44328/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:44328/signout-callback-oidc"},
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "SOF",
                        "Auth"
                    },
                    RequireConsent = false

                }
            };
        }
    }
}
