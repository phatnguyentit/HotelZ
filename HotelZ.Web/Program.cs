using HotelZ.Initializer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HotelZ.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(builder =>
            {
                builder.UseStaticWebAssets();
                builder.UseStartup<Startup>();
            }).Build().Run();
        }
    }
}