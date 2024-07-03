using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddIdentityServer()
                .AddInMemoryClients(IdentityServerConfiguration.Clients)
                .AddInMemoryApiScopes(IdentityServerConfiguration.ApiScopes)
                .AddDeveloperSigningCredential();

            var app = builder.Build();

            app.UseIdentityServer();

            app.Run();
        }
    }
}
