namespace VehicleMonitoringWebApp.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; } = "";
        public string Role { get; set; } = "";           // "Employee" atau "Driver"
    }
}