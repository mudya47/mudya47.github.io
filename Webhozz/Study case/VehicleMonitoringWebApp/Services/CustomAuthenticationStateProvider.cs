using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace VehicleMonitoringWebApp.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _js;
        private ClaimsPrincipal _cachedUser = new(new ClaimsIdentity());

        private const string UsernameKey = "username";
        private const string RoleKey = "role"; // <-- simpan role di sessionStorage

        public CustomAuthenticationStateProvider(IJSRuntime js)
        {
            _js = js;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // if we already have a signed-in user in memory, use it
            if (_cachedUser?.Identity?.IsAuthenticated == true)
                return new AuthenticationState(_cachedUser);

            try
            {
                var username = await _js.InvokeAsync<string>("sessionStorage.getItem", "username");
                var role = await _js.InvokeAsync<string>("sessionStorage.getItem", "role");

                if (string.IsNullOrWhiteSpace(username))
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

                var claims = new List<Claim> { new(ClaimTypes.Name, username) };
                if (!string.IsNullOrWhiteSpace(role))
                    claims.Add(new Claim(ClaimTypes.Role, role));

                var identity = new ClaimsIdentity(claims, "CustomAuth");
                _cachedUser = new ClaimsPrincipal(identity);    // cache it
                return new AuthenticationState(_cachedUser);
            }
            catch
            {
                // prerender: JS interop not available → stay anonymous (but we’ll have _cachedUser next render)
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

        /// <summary>
        /// Panggil ini saat login sukses. Role = "Employee" atau "Driver".
        /// </summary>
        public async Task SignInAsync(string username, string role)
        {
            await _js.InvokeVoidAsync("sessionStorage.setItem", "username", username);
            await _js.InvokeVoidAsync("sessionStorage.setItem", "role", role);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, username),
                new(ClaimTypes.Role, role)
            };

            var identity = new ClaimsIdentity(claims, "CustomAuth");
            _cachedUser = new ClaimsPrincipal(identity);        // cache for prerender
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_cachedUser)));
        }

        /// <summary>
        /// (Back-compat) kalau masih ada kode lama yang manggil ini.
        /// Default-kan ke role Driver supaya tidak null.
        /// </summary>
        public Task MarkUserAsAuthenticated(string username)
            => SignInAsync(username, "Driver");

        public async Task MarkUserAsLoggedOut()
        {
            await _js.InvokeVoidAsync("sessionStorage.removeItem", UsernameKey);
            await _js.InvokeVoidAsync("sessionStorage.removeItem", RoleKey);

            _cachedUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_cachedUser)));
        }
    }
}
