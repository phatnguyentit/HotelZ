using System;
using HotelZ.Core;
using HotelZ.Core.Data;
using HotelZ.Core.Data.Entities;
using HotelZ.Module.Identity.Services;
using HotelZ.Module.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Module.Identity
{
    public class Startup : BaseModuleStartup
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<HotelZDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(opt =>
                {
                    opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                })
                .AddCookie(opt =>
                {
                    opt.LoginPath = "/Identity/Account/Login";
                    opt.LogoutPath = "/Identity/Account/Logout";
                    opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                })
                .AddGoogle(opt =>
                {
                    opt.ClientId = configuration["Authentication:Google:ClientId"];
                    opt.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                });
            
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}