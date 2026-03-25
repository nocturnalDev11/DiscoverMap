using DiscoverMap.Server.Features.Pins.Models;

namespace DiscoverMap.Server.Features.Auth.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public List<Pin> Pins { get; set; } = new();
    }
}
