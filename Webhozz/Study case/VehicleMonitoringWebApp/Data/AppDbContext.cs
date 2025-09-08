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
        public DbSet<EmployeeLog> EmployeeLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransportLog>()
                .ToTable("TransportLog") 
                .Property(e => e.Efisiensi_BBM)
                .HasConversion<string>();

            modelBuilder.Entity<EmployeeLog>()
                .ToTable("EmployeeLog")
                .Property(e => e.Efisiensi_BBM)
                .HasConversion<string>();
        }
    }
}