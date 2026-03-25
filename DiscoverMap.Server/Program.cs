using DiscoverMap.Server.Configurations;
using DiscoverMap.Server.Data;
using DiscoverMap.Server.Data.Seeders;
using DiscoverMap.Server.Repositories;
using DiscoverMap.Server.Repositories.Interfaces;
using DiscoverMap.Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repositories & services (scoped, not singleton)
builder.Services.AddScoped<IPinRepository, PinRepository>();
builder.Services.AddScoped<PinService>();

// Add controllers, CORS, etc.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddCorsPolicy();

var app = builder.Build();

// Seed database (optional)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await PinSeeder.SeedAsync(dbContext);
}

// Middleware
app.UseCors("AllowFrontend");
app.UseDefaultFiles();
app.MapStaticAssets();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();