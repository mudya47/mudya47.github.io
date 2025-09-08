using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using VehicleMonitoringWebApp.Models;

namespace VehicleMonitoringWebApp.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var hashedPassword = HashPassword(password);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await conn.OpenAsync();

            using var cmd = new SqlCommand(@"
                SELECT TOP 1 ID, Username, PasswordHash, [Role]
                FROM dbo.Users
                WHERE Username = @username AND PasswordHash = @password;", conn);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 255).Value = hashedPassword;

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new User
                {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    Username = reader.GetString(reader.GetOrdinal("Username")),
                    // PasswordHash optional kalau mau diisi:
                    // PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                    Role = reader.GetString(reader.GetOrdinal("Role")) // <-- penting
                };
            }

            return null;
        }

        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}