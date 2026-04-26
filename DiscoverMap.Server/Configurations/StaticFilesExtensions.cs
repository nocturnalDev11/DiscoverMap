using Microsoft.AspNetCore.Builder;

namespace DiscoverMap.Server.Configurations
{
    public static class StaticFilesExtensions
    {
        public static void MapStaticAssets(this WebApplication app)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}