using Microsoft.EntityFrameworkCore;
using TransmittalTrackerAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// CORS untuk Vite dev server
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseCors("AllowReactApp");

// ⬇ serve file /uploads/...
app.UseStaticFiles();

// (opsional) kalau sengaja overwrite nama file yang sama,
// uncomment blok ini untuk memaksa no-cache:
//
// app.UseStaticFiles(new StaticFileOptions
// {
//     OnPrepareResponse = ctx =>
//     {
//         ctx.Context.Response.Headers.CacheControl = "no-store, no-cache, must-revalidate";
//         ctx.Context.Response.Headers.Pragma = "no-cache";
//         ctx.Context.Response.Headers.Expires = "-1";
//     }
// });

app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();
