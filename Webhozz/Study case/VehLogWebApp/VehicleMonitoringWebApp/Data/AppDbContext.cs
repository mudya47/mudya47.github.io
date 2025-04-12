using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using VehicleMonitoringWebApp.Models;

namespace VehicleMonitoringWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<TransportLog> TransportLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransportLog>()
                .ToTable("TransportLog") // 👈 Tambahkan ini
                .Property(e => e.Efisiensi_BBM)
                .HasConversion<string>();
        }
    }
}