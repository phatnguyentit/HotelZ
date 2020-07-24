using HotelZ.Core.Data.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using HotelZ.Core.Configuration.Interfaces;

namespace HotelZ.Core.Data
{
    public class Startup : IPartialStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelZDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

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
        }
    }
}