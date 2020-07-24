using HotelZ.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Core
{
    public class Startup : IPartialStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            
        }
    }
}
