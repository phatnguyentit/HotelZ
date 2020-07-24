using HotelZ.Core.Data.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using HotelZ.Core.Interfaces;

namespace HotelZ.Core.Data
{
    public class Startup : IPartialStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelZDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}