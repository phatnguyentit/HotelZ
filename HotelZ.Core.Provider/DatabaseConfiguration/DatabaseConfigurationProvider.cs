using HotelZ.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelZ.Core.Provider.DatabaseConfiguration
{
    public class DatabaseConfigurationProvider : ConfigurationProvider
    {
        private readonly Action<DbContextOptionsBuilder> _dbContextOptions;

        public DatabaseConfigurationProvider(Action<DbContextOptionsBuilder> dbContextOptionsBuilder)
        {
            _dbContextOptions = dbContextOptionsBuilder;
        }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<HotelZDbContext>();

            _dbContextOptions(builder);

            using (var ctx = new HotelZDbContext(builder.Options))
            {
                Data = ctx.Configurations.Any()
                    ? ctx.Configurations.ToDictionary(c => c.Key, c => c.Value)
                    : new Dictionary<string, string>();
            }
        }
    }
}
