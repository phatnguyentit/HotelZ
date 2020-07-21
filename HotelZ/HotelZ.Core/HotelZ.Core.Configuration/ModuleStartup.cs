using HotelZ.Core.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace HotelZ.Core.Configuration
{
    public abstract class ModuleStartup : IPartialStartup
    {
        public abstract void ConfigureServices(IServiceCollection services, IConfiguration configuration);

        public virtual void RegisterControllers(IServiceCollection services, IEnumerable<Type> controllerTypes)
        {
            foreach (var controller in controllerTypes)
            {
                services.AddTransient(controller, controller);
            }
        }
    }
}
