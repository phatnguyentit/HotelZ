using HotelZ.Core.Configuration;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Module.Admin
{
    public class Startup : BaseModuleStartup
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}