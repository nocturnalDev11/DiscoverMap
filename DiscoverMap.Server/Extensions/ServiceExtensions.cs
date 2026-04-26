using DiscoverMap.Server.Configurations;
using DiscoverMap.Server.Data;
using DiscoverMap.Server.Features.Auth.Repositories;
using DiscoverMap.Server.Features.Auth.Repositories.Interfaces;
using DiscoverMap.Server.Features.Auth.Services;
using DiscoverMap.Server.Features.Pins.Repositories;
using DiscoverMap.Server.Features.Pins.Repositories.Interfaces;
using DiscoverMap.Server.Features.Pins.Services;
using Microsoft.EntityFrameworkCore;

namespace DiscoverMap.Server.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Repositories & Services
            services.AddScoped<IPinRepository, PinRepository>();
            services.AddScoped<PinService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<AuthService>();

            // Controllers, OpenAPI, CORS
            services.AddControllers();
            services.AddOpenApi();
            services.AddCorsPolicy();
        }
    }
}