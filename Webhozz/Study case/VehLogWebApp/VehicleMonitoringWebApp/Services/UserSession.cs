using VehicleMonitoringWebApp.Models;

namespace VehicleMonitoringWebApp.Services
{
    public class UserSession
    {
        public User? CurrentUser { get; private set; }

        public void SetUser(User user)
        {
            CurrentUser = user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public bool IsLoggedIn => CurrentUser != null;
    }
}
