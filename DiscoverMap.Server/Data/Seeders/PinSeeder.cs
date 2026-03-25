using DiscoverMap.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscoverMap.Server.Data.Seeders
{
    public static class PinSeeder
    {
        public static async Task SeedAsync(AppDbContext dbContext)
        {
            await dbContext.Database.MigrateAsync();

            if (await dbContext.Pins.AnyAsync()) return;

            var pins = new List<Pin>
            {
                new Pin
                {
                    Title = "First Pin",
                    Description = "This is the first real pin",
                    Category = "Landmark",
                    Latitude = 14.5995,
                    Longitude = 120.9842,
                    ImageUrl = null
                },
                new Pin
                {
                    Title = "Second Pin",
                    Description = "Another cool location",
                    Category = "Restaurant",
                    Latitude = 14.5800,
                    Longitude = 120.9900,
                    ImageUrl = null
                }
            };

            await dbContext.Pins.AddRangeAsync(pins);
            await dbContext.SaveChangesAsync();
        }
    }
}