using DiscoverMap.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DiscoverMap.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pin> Pins { get; set; }
    }
}