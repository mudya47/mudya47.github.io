using Microsoft.EntityFrameworkCore;
using VehicleMonitoringWebApp.Data;
using VehicleMonitoringWebApp.Models;

namespace VehicleMonitoringWebApp.Services
{
    public class TransportLogService
    {
        private readonly AppDbContext _context;

        public TransportLogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TransportLog>> GetAllLogsAsync()
        {
            return await _context.TransportLogs
                .OrderBy(t => t.Tanggal)
                .ToListAsync();
        }

        public async Task<List<TransportLog>> GetLogsAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.TransportLogs
                .Where(t => t.Tanggal >= startDate && t.Tanggal <= endDate)
                .OrderBy(t => t.Tanggal)
                .ToListAsync();
        }

        public async Task AddLogAsync(TransportLog log)
        {
            _context.TransportLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<TransportLog?> GetLogByIdAsync(int id)
        {
            return await _context.TransportLogs.FindAsync(id);
        }

        public async Task UpdateLogAsync(TransportLog log)
        {
            _context.TransportLogs.Update(log);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLogAsync(int id)
        {
            var log = await _context.TransportLogs.FindAsync(id);
            if (log != null)
            {
                _context.TransportLogs.Remove(log);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateAsync(TransportLog log)
        {
            _context.TransportLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        //delete function
        public async Task DeleteAsync(int id)
        {
            var log = await _context.TransportLogs.FindAsync(id);
            if (log != null)
            {
                _context.TransportLogs.Remove(log);
                await _context.SaveChangesAsync();
            }
        }

        //Edit function
        public async Task<TransportLog?> GetByIdAsync(int id)
        {
            return await _context.TransportLogs.FindAsync(id);
        }

        public async Task UpdateAsync(TransportLog log)
        {
            _context.TransportLogs.Update(log);
            await _context.SaveChangesAsync();
        }
    }
}