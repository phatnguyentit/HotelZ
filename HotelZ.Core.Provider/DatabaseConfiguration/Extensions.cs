using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

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
