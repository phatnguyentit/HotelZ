using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Initializer
{
    public abstract class BaseInitializer
    {
        protected IServiceCollection ServiceCollection { get; private set; }
        protected IConfiguration Configuration { get; private set; }
        protected abstract void Execute();

        public void Execute(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            ServiceCollection = serviceCollection;
            Configuration = configuration;
            Execute();
        }
    }
}