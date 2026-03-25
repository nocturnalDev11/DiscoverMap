using DiscoverMap.Server.Data;
using DiscoverMap.Server.Data.Seeders;

namespace DiscoverMap.Server.Common.Helpers
{
    public static class SeedExtensions
    {
        public static async Task SeedDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await PinSeeder.SeedAsync(dbContext);
        }
    }
}
