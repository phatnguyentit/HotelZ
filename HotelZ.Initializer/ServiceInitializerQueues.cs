using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Initializer
{
    public class ServiceInitializerQueues
    {
        private readonly IServiceCollection _services;
        private readonly IConfiguration _configuration;
        private readonly Queue<BaseInitializer> _initializers = new Queue<BaseInitializer>();

        public ServiceInitializerQueues(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        public void Queue(BaseInitializer initializer)
        {
            _initializers.Enqueue(initializer);
        }

        internal void Execute()
        {
            while (_initializers.Count > 0)
            {
                _initializers.Dequeue().Execute(_services, _configuration);
            }
        }
    }
}