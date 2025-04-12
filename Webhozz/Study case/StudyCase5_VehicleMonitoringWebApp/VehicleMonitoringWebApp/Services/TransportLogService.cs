using Microsoft.Data.SqlClient;
using System.Data;
using VehicleMonitoringWebApp.Models;

namespace VehicleMonitoringWebApp.Services;

public class TransportLogService
{
    private readonly IConfiguration _config;
    private readonly string _connectionString;

    public TransportLogService(IConfiguration config)
    {
        _config = config;
        _connectionString = _config.GetConnectionString("TransportDB") ?? string.Empty;
    }

    public async Task<List<TransportLog>> GetLogsAsync(DateTime startDate, DateTime endDate)
    {
        var logs = new List<TransportLog>();

        using SqlConnection conn = new(_connectionString);
        string query = @"SELECT * FROM TransportLog WHERE Tanggal BETWEEN @start AND @end";

        using SqlCommand cmd = new(query, conn);
        cmd.Parameters.AddWithValue("@start", startDate);
        cmd.Parameters.AddWithValue("@end", endDate);

        await conn.OpenAsync();
        using SqlDataReader reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            logs.Add(ReadLog(reader));
        }

        return logs;
    }

    public async Task<List<TransportLog>> GetAllLogsAsync()
    {
        var logs = new List<TransportLog>();

        using SqlConnection conn = new(_connectionString);
        string query = "SELECT * FROM TransportLog ORDER BY Tanggal DESC";

        using SqlCommand cmd = new(query, conn);
        await conn.OpenAsync();
        using SqlDataReader reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            logs.Add(ReadLog(reader));
        }

        return logs;
    }

    public async Task<List<TransportLog>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await GetLogsAsync(startDate, endDate);
    }

    public async Task<TransportLog?> GetLogByIdAsync(int id)
    {
        using SqlConnection conn = new(_connectionString);
        string query = "SELECT * FROM TransportLog WHERE ID = @id";

        using SqlCommand cmd = new(query, conn);
        cmd.Parameters.AddWithValue("@id", id);

        await conn.OpenAsync();
        using SqlDataReader reader = await cmd.ExecuteReaderAsync();

        return await reader.ReadAsync() ? ReadLog(reader) : null;
    }

    public async Task CreateLogAsync(TransportLog log)
    {
        using SqlConnection conn = new(_connectionString);
        string query = @"INSERT INTO TransportLog (Tanggal, Qty_L, Harga_BBM_Rp, Adometer_Buka, Adometer_Tutup, Biaya_Toll_Rp, Parkir_Rp, Job_Number, Supir, Efisiensi_BBM) 
                         VALUES (@Tanggal, @Qty_L, @Harga, @AdoBuka, @AdoTutup, @Tol, @Parkir, @Job, @Supir, @Efisien)";

        using SqlCommand cmd = new(query, conn);
        FillParams(cmd, log);

        await conn.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
    }

    public async Task UpdateLogAsync(TransportLog log)
    {
        using SqlConnection conn = new(_connectionString);
        string query = @"UPDATE TransportLog SET Tanggal=@Tanggal, Qty_L=@Qty_L, Harga_BBM_Rp=@Harga, Adometer_Buka=@AdoBuka, 
                         Adometer_Tutup=@AdoTutup, Biaya_Toll_Rp=@Tol, Parkir_Rp=@Parkir, Job_Number=@Job, Supir=@Supir, Efisiensi_BBM=@Efisien WHERE ID=@id";

        using SqlCommand cmd = new(query, conn);
        FillParams(cmd, log);
        cmd.Parameters.AddWithValue("@id", log.ID);

        await conn.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
    }

    private static void FillParams(SqlCommand cmd, TransportLog log)
    {
        cmd.Parameters.AddWithValue("@Tanggal", log.Tanggal);
        cmd.Parameters.AddWithValue("@Qty_L", log.Qty_L);
        cmd.Parameters.AddWithValue("@Harga", log.Harga_BBM_Rp);
        cmd.Parameters.AddWithValue("@AdoBuka", log.Adometer_Buka);
        cmd.Parameters.AddWithValue("@AdoTutup", log.Adometer_Tutup);
        cmd.Parameters.AddWithValue("@Tol", log.Biaya_Toll_Rp);
        cmd.Parameters.AddWithValue("@Parkir", log.Parkir_Rp);
        cmd.Parameters.AddWithValue("@Job", log.Job_Number);
        cmd.Parameters.AddWithValue("@Supir", log.Supir);
        cmd.Parameters.AddWithValue("@Efisien", (int)log.Efisiensi_BBM);
    }

    private static TransportLog ReadLog(SqlDataReader reader) => new()
    {
        ID = Convert.ToInt32(reader["ID"]),
        Tanggal = Convert.ToDateTime(reader["Tanggal"]),
        Qty_L = (float)Convert.ToDouble(reader["Qty_L"]),
        Harga_BBM_Rp = Convert.ToInt32(reader["Harga_BBM_Rp"]),
        Adometer_Buka = Convert.ToInt32(reader["Adometer_Buka"]),
        Adometer_Tutup = Convert.ToInt32(reader["Adometer_Tutup"]),
        Biaya_Toll_Rp = Convert.ToInt32(reader["Biaya_Toll_Rp"]),
        Parkir_Rp = Convert.ToInt32(reader["Parkir_Rp"]),
        Job_Number = reader["Job_Number"].ToString() ?? "",
        Supir = reader["Supir"].ToString() ?? "",
         Efisiensi_BBM = Enum.IsDefined(typeof(Efisiensi), (int)reader["Efisiensi_BBM"])
        ? (Efisiensi)(int)reader["Efisiensi_BBM"]
        : Efisiensi.Good
    };
}