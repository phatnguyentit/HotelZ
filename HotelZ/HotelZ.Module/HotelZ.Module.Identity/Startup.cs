﻿using HotelZ.Core.Configuration;
using HotelZ.Module.Identity.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Module.Identity
{
    public class Startup : ModuleStartup
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthService, AuthService>();
        }
    }
}