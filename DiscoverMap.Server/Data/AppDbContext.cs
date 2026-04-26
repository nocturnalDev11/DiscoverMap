using DiscoverMap.Server.Features.Auth.Models;
using DiscoverMap.Server.Features.Pins.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscoverMap.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Pin> Pins { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pin>()
                .HasOne(p => p.User)
                .WithMany(u => u.Pins)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
