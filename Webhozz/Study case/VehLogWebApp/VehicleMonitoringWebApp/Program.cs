using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using VehicleMonitoringWebApp.Data;
using VehicleMonitoringWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Register Razor pages & Blazor Server
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// ✅ Tambahkan AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Tambahkan TransportLogService
builder.Services.AddScoped<TransportLogService>();

// ==========================================
// ✅ DI SINI letakkan baris `var app = builder.Build();`
var app = builder.Build();

// Middleware & routing setup
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Endpoint mapping
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();