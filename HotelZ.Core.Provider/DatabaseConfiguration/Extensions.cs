using HotelZ.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelZ.Core.Provider.DatabaseConfiguration
{
    public static class Extensions
    {
        public static IConfigurationBuilder AddDatabaseConfiguration(this IConfigurationBuilder configurationBuilder, Action<DbContextOptionsBuilder> options)
        {
            return configurationBuilder.Add(new DatabaseConfigurationSource(options));
        }
    }
}
