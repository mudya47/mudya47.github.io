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

            using SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await conn.OpenAsync();

            var command = new SqlCommand("SELECT * FROM Users WHERE Username = @username AND PasswordHash = @password", conn);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 255).Value = hashedPassword;

            using var reader = await command.ExecuteReaderAsync();
            if (reader.Read())
            {
                return new User
                {
                    ID = (int)reader["ID"],
                    Username = (string)reader["Username"]
                };
            }

            return null;
        }

        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}