using DiscoverMap.Server.Features.Auth.Controllers;

namespace DiscoverMap.Server.Routes
{
    public static class AuthRoutes
    {
        public static void MapAuthRoutes(this WebApplication app)
        {
            app.MapControllerRoute(
                name: "auth",
                pattern: "api/auth/{action}",
                defaults: new { controller = "Auth" }
            );
        }
    }
}
