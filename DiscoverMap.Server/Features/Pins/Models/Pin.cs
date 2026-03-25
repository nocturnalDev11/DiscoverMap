using DiscoverMap.Server.Features.Auth.Models;

namespace DiscoverMap.Server.Features.Pins.Models
{
    public class Pin
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? ImageUrl { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
