using DiscoverMap.Server.Data;
using Microsoft.EntityFrameworkCore;
using DiscoverMap.Server.Features.Pins.Models;

namespace DiscoverMap.Server.Features.Pins.Repositories
{
    public class PinRepository
    {
        private readonly AppDbContext _dbContext;

        public PinRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Pin>> GetAllAsync()
        {
            return await _dbContext.Pins.ToListAsync();
        }

        public async Task AddAsync(Pin pin)
        {
            await _dbContext.Pins.AddAsync(pin);
            await _dbContext.SaveChangesAsync();
        }
    }
}
