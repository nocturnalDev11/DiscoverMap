using DiscoverMap.Server.Models;

namespace DiscoverMap.Server.Repositories.Interfaces
{
    public interface IPinRepository
    {
        Task<List<Pin>> GetAllAsync();
        Task AddAsync(Pin pin);
    }
}