using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APIResource.Data;
namespace APIResource
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<APIResourceContext>(options =>
                options.UseInMemoryDatabase("MoviesDatabase"));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            SeedDatabase(app);

            app.Run();
        }

        static async void SeedDatabase(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var moviesContext = services.GetRequiredService<APIResourceContext>();
                MoviesContextSeed.SeedAsync(moviesContext);
            }
        }
    }
}
