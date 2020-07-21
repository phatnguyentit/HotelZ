using Microsoft.AspNetCore.Builder;

namespace HotelZ.Core.Configuration.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Add middleware for app
        /// </summary>
        /// <param name="app"></param>
        public static void UseHotelZMiddlewares(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

            });
        }
    }
}
