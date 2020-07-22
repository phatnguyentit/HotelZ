using HotelZ.Initializer.Core;
using HotelZ.Initializer.Module;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Initializer
{
    public static class Extenssions
    {
        public static void RunServicesInitializer(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            var initializers = new ServiceInitializerQueues(services, configuration);
            initializers.Queue(new CoreServiceInitializer());
            initializers.Queue(new ModuleInitializer());
            
            initializers.Execute();
        }
    }
}