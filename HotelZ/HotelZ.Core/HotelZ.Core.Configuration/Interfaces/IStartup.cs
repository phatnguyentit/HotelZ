using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Core.Configuration.Interfaces
{
    public interface IPartialStartup
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}
