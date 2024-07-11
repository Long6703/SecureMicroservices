using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace IdentityServer
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<Client> Clients =>

            // we have 4 authentication flows
            // 1. client credentials : this is for machine to machine communication, in this solution we use this to communicate between the client and the API
            // 2. authorization code : this is for interactive applications, in this solution we use this to authenticate the user and get the access token with identityServer
            // 3. implicit : this is flow for browser based applications, this is not recommended anymore because accesstoken is passed in the url
            // 4. hybrid : this is a combination of authorization code and implicit flow, this is used for browser based applications
            
            new Client[]
            {
                //new Client
                //{
                //    ClientId = "movieClient",
                //    ClientName = "Movie Client",
                //    // this is client credentials flow
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = { new Secret("secret".Sha256()) },
                //    AllowedScopes = { "movieAPI" }
                //},
                new Client
                {
                    ClientId = "movies_mvc_client",
                    ClientName = "Movies MVC Web App",
                    // this is hybrid flow
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RequirePkce = false,
                    AllowRememberConsent = false,
                    RedirectUris = new List<string>()
                    {
                        // this url is where the user will be redirected after the login, that mean we back to the client when we retrive the token
                        "https://localhost:5002/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        // this url is where the user will be redirected after the logout
                        "https://localhost:5002/signout-callback-oidc"
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Email,
                        "movieAPI",
                        "roles"
                    }
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Email(),
                new IdentityResource("roles", "User roles", new List<string> { "role" })
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
                new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "longnk",
                    Password = "long6703",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "longnk"),
                        new Claim(JwtClaimTypes.FamilyName, "long6703")
                    }
                }
            };
    }
}
