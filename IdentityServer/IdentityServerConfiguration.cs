using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "movieClient",
                    ClientName = "Movie Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "movieAPI" }
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("movieAPI", "MovieAPI")
            };

        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                
            };

        
    }
}
