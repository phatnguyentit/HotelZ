using HotelZ.Core.Configuration;
using HotelZ.Core.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Module.ReportJob
{
    public class Startup : ModuleStartup
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<ReportJobService>();
        }
    }
}
