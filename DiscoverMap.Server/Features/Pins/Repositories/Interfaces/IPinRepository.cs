using DiscoverMap.Server.Features.Pins.Models;

namespace DiscoverMap.Server.Features.Pins.Repositories.Interfaces
{
    public interface IPinRepository
    {
        Task<List<Pin>> GetAllAsync();
        Task AddAsync(Pin pin);
    }
}
