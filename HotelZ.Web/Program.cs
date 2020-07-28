using HotelZ.Core.Provider.DatabaseConfiguration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace HotelZ.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((ctx, builder) =>
                {
                    var config = builder.Build();
                    builder.AddDatabaseConfiguration(optionBuilder =>
                    {
                        optionBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                    });
                })
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.UseStaticWebAssets();
                    builder.UseStartup<Startup>();

                }).Build().Run();
        }
    }
}