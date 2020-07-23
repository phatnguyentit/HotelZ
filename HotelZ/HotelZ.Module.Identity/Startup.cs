using HotelZ.Core.Configuration;
using HotelZ.Module.Identity.Services;
using HotelZ.Module.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Module.Identity
{
    public class Startup : BaseModuleStartup
    {
        public override void ConfigEndpointRoute(IEndpointRouteBuilder endpointRouteBuilder)
        {
            
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}