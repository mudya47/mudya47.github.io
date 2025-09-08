using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using VehicleMonitoringWebApp.Data;
using VehicleMonitoringWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ Register Razor Pages & Blazor Server
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });

// ✅ Opsional: Tambahan untuk ketahanan circuit & interop
builder.Services.Configure<CircuitOptions>(options =>
{
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
    options.JSInteropDefaultCallTimeout = TimeSpan.FromSeconds(30);
});

// ✅ Tambahkan DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Tambahkan Service untuk data log kendaraan
builder.Services.AddScoped<TransportLogService>();
builder.Services.AddScoped<EmployeeLogService>();

// ✅ Tambahkan Authentication & Authorization
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("EmployeeOnly", p => p.RequireRole("Employee"));
    options.AddPolicy("DriverOnly", p => p.RequireRole("Driver"));
});
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddScoped<UserSession>();

//Toast
builder.Services.AddScoped<ToastService>();

// ✅ Bikin dan jalankan WebApp
var app = builder.Build();

// ✅ Middleware dan Routing
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// ✅ Endpoint mapping
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();