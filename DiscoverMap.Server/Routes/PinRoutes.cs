using DiscoverMap.Server.Features.Pins.Controllers;

namespace DiscoverMap.Server.Routes
{
    public static class PinRoutes
    {
        public static void MapPinRoutes(this WebApplication app)
        {
            app.MapControllerRoute(
                name: "pins",
                pattern: "api/pins/{action=Index}/{id?}",
                defaults: new { 
                    controller = nameof(PinController)
                }
            );
        }
    }
}
