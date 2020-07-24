using System;
using System.Collections.Generic;
using HotelZ.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Core
{
    public abstract class BaseModuleStartup : IPartialStartup
    {
        public abstract void ConfigureServices(IServiceCollection services, IConfiguration configuration);

        public virtual void RegisterControllers(IServiceCollection services, List<Type> controllerTypes)
            => controllerTypes.ForEach(controller => services.AddTransient(controller, controller));
    }
}
