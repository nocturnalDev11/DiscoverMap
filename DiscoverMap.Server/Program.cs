using DiscoverMap.Server.Common.Helpers;
using DiscoverMap.Server.Extensions;
using DiscoverMap.Server.Routes;

var builder = WebApplication.CreateBuilder(args);

// Add Services
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Seed Database
await app.SeedDatabaseAsync();

// Middleware
// app.UseApplicationMiddleware();

// Cors
app.UseCors("AllowFrontend");

// Routes
app.MapPinRoutes();
app.MapAuthRoutes();

// Swagger / OpenAPI
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Fallback
app.MapFallbackToFile("/index.html");

app.Run();