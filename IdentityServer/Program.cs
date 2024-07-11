using IdentityServer4.Models;
using IdentityServer4.Test;
using IdentityServerHost.Quickstart.UI;

namespace IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddIdentityServer()
                .AddInMemoryClients(IdentityServerConfiguration.Clients)
                .AddInMemoryApiScopes(IdentityServerConfiguration.ApiScopes)
                .AddInMemoryIdentityResources(IdentityServerConfiguration.IdentityResources)
                .AddTestUsers(TestUsers.Users)
                .AddDeveloperSigningCredential();

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.Run();
        }
    }
}
