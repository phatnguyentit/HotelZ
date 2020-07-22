using System;
using System.Collections.Generic;
using HotelZ.Core.Configuration.Interfaces;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Core.Configuration
{
    public abstract class BaseModuleStartup : IPartialStartup
    {
        public abstract void ConfigureServices(IServiceCollection services, IConfiguration configuration);

        public virtual void RegisterControllers(IServiceCollection services, List<Type> controllerTypes)
            => controllerTypes.ForEach(controller => services.AddTransient(controller, controller));

        public virtual void ConfigEndpointRoute(IEndpointRouteBuilder endpointRouteBuilder)
        {

        }
    }
}
