using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VehicleMonitoringWebApp.Data;
using VehicleMonitoringWebApp.Models;

namespace VehicleMonitoringWebApp.Services
{
    public class EmployeeLogService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public EmployeeLogService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<EmployeeLog>> GetAllLogsAsync()
        {
            return await _context.EmployeeLog
                .OrderBy(t => t.Tanggal)
                .ToListAsync();
        }

        public async Task<List<EmployeeLog>> GetLogsAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.EmployeeLog
                .Where(t => t.Tanggal >= startDate && t.Tanggal <= endDate)
                .OrderBy(t => t.Tanggal)
                .ToListAsync();
        }

        public async Task AddLogAsync(EmployeeLog log)
        {
            _context.EmployeeLog.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<EmployeeLog?> GetLogByIdAsync(int id)
        {
            return await _context.EmployeeLog.FindAsync(id);
        }

        public async Task UpdateLogAsync(EmployeeLog log)
        {
            _context.EmployeeLog.Update(log);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLogAsync(int id)
        {
            var log = await _context.EmployeeLog.FindAsync(id);
            if (log != null)
            {
                _context.EmployeeLog.Remove(log);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateAsync(EmployeeLog log)
        {
            // hitung efisiensi dulu
            log.Efisiensi_BBM = Enum.TryParse<Efisiensi>(
                GetEfisiensiKategori(log.KM, log.Qty_L), out var ef
            ) ? ef : Efisiensi.Unfair;

            _context.EmployeeLog.Add(log);
            await _context.SaveChangesAsync();
        }

        //delete function
        public async Task DeleteAsync(int id)
        {
            var log = await _context.EmployeeLog.FindAsync(id);
            if (log != null)
            {
                _context.EmployeeLog.Remove(log);
                await _context.SaveChangesAsync();
            }
        }

        //Edit function
        public async Task<EmployeeLog?> GetByIdAsync(int id)
        {
            return await _context.EmployeeLog.FindAsync(id);
        }

        public async Task UpdateAsync(EmployeeLog log)
        {
            _context.EmployeeLog.Update(log);
            await _context.SaveChangesAsync();
        }

        private string GetEfisiensiKategori(double km, double qtyL)
        {
            if (qtyL == 0) return "Unfair";
            var ratio = km / qtyL;

            return ratio >= 8 ? "Fair" : "Unfair"; ;
        }
    }
}