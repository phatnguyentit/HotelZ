using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using HotelZ.Core.Configuration.Interfaces;
using HotelZ.Core.Configuration;

namespace HotelZ.Module.Notification
{
    public class Startup : ModuleStartup
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Donothing
        }
    }
}
