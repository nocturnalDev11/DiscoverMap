using DiscoverMap.Server.Features.Auth.Models;
using DiscoverMap.Server.Features.Pins.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscoverMap.Server.Data.Seeders
{
    public static class PinSeeder
    {
        public static async Task SeedAsync(AppDbContext dbContext)
        {
            await dbContext.Database.MigrateAsync();

            //-- seed dummy user --
            if (!await dbContext.Users.AnyAsync())
            {
                var dummyUser = new User
                {
                    Username = "lutz",
                    Email = "lutzydummy@discovermap.local",
                    PasswordHash = "not-a-real-hash"
                };
                await dbContext.Users.AddAsync(dummyUser);
                await dbContext.SaveChangesAsync();
            }

            //-- seed pins under dummy user --
            if (!await dbContext.Pins.AnyAsync())
            {
                var userId = (await dbContext.Users.FirstAsync()).Id;

                var pins = new List<Pin>
                {
                    new Pin
                    {
                        Title = "First Pin",
                        Description = "This is the first real pin",
                        Category = "Landmark",
                        Latitude = 14.5995,
                        Longitude = 120.9842,
                        UserId = userId
                    },
                    new Pin
                    {
                        Title = "Second Pin",
                        Description = "Another cool location",
                        Category = "Restaurant",
                        Latitude = 14.5800,
                        Longitude = 120.9900,
                        UserId = userId
                    }
                };

                await dbContext.Pins.AddRangeAsync(pins);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
