using Microsoft.EntityFrameworkCore;
using TransmittalTrackerAPI.Models;

namespace TransmittalTrackerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Transmittal> Transmittals { get; set; }
    }
}