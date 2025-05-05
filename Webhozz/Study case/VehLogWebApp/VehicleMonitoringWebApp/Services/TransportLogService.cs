using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VehicleMonitoringWebApp.Data;
using VehicleMonitoringWebApp.Models;

namespace VehicleMonitoringWebApp.Services
{
    public class TransportLogService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public TransportLogService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
            // Hitung efisiensi dan set ke kolom
            log.Efisiensi_BBM = Enum.TryParse<Efisiensi>(GetEfisiensiKategori(log.KM, log.Qty_L), out var ef) ? ef : Efisiensi.Unfair;

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await conn.OpenAsync();

            var cmd = new SqlCommand(@"
        INSERT INTO TransportLog 
        (Tanggal, Qty_L, Harga_BBM_Rp, Adometer_Buka, Adometer_Tutup, 
         Biaya_Toll_Rp, Parkir_Rp, Job_Number, Supir, Efisiensi_BBM, Nopol)
        VALUES 
        (@Tanggal, @Qty_L, @Harga_BBM_Rp, @Adometer_Buka, @Adometer_Tutup, 
         @Biaya_Toll_Rp, @Parkir_Rp, @Job_Number, @Supir, @Efisiensi_BBM, @Nopol)", conn);

            cmd.Parameters.AddWithValue("@Tanggal", log.Tanggal);
            cmd.Parameters.AddWithValue("@Qty_L", log.Qty_L);
            cmd.Parameters.AddWithValue("@Harga_BBM_Rp", log.Harga_BBM_Rp);
            cmd.Parameters.AddWithValue("@Adometer_Buka", log.Adometer_Buka);
            cmd.Parameters.AddWithValue("@Adometer_Tutup", log.Adometer_Tutup);
            cmd.Parameters.AddWithValue("@Biaya_Toll_Rp", log.Biaya_Toll_Rp);
            cmd.Parameters.AddWithValue("@Parkir_Rp", log.Parkir_Rp);
            cmd.Parameters.AddWithValue("@Job_Number", log.Job_Number);
            cmd.Parameters.AddWithValue("@Supir", log.Supir);
            cmd.Parameters.AddWithValue("@Efisiensi_BBM", log.Efisiensi_BBM?.ToString());
            cmd.Parameters.AddWithValue("@Nopol", log.Nopol);

            await cmd.ExecuteNonQueryAsync();
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

        private string GetEfisiensiKategori(double km, double qtyL)
        {
            if (qtyL == 0) return "Unfair";
            var ratio = km / qtyL;

            return ratio >= 8 ? "Fair" : "Unfair"; ;
        }
    }
}