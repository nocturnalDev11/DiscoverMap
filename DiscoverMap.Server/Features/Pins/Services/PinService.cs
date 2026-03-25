using DiscoverMap.Server.Features.Pins.Models;
using DiscoverMap.Server.Features.Pins.Repositories.Interfaces;

namespace DiscoverMap.Server.Features.Pins.Services
{
    public class PinService
    {
        private readonly IPinRepository _repo;

        public PinService(IPinRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Pin>> GetAllPinsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task CreatePinAsync(Pin pin)
        {
            await _repo.AddAsync(pin);
        }
    }
}
