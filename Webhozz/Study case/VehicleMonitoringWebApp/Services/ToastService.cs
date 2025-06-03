using System;
using System.Threading.Tasks;

namespace VehicleMonitoringWebApp.Services
{
    public class ToastService
    {
        public event Func<string, bool, int, Task>? OnShow;

        public async Task ShowToastAsync(string message, bool isError = false, int duration = 3000)
        {
            if (OnShow != null)
            {
                await OnShow.Invoke(message, isError, duration);
            }
        }
    }
}
