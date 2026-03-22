using DiscoverMap.Server.Models;
using DiscoverMap.Server.Repositories;

namespace DiscoverMap.Server.Services
{
    namespace DiscoverMap.Server.Services
    {
        public class PinService
        {
            private readonly PinRepository _repo;

            public PinService(PinRepository repo)
            {
                _repo = repo;
            }

            public List<Pin> GetAllPins()
            {
                return _repo.GetAll();
            }

            public void CreatePin(Pin pin)
            {
                _repo.Add(pin);
            }
        }
    }
}
