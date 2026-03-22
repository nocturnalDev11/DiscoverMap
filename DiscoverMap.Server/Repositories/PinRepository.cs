using DiscoverMap.Server.Models;

namespace DiscoverMap.Server.Repositories
{
    public class PinRepository
    {
        private static List<Pin> _pins = new List<Pin>();

        public List<Pin> GetAll()
        {
            return _pins;
        }

        public void Add(Pin pin)
        {
            pin.Id = _pins.Count + 1;
            _pins.Add(pin);
        }
    }
}
