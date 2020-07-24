using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Core.Interfaces
{
    public interface IPartialStartup
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}
