using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace HotelZ.Core.Provider.DatabaseConfiguration
{
    internal class DatabaseConfigurationSource : IConfigurationSource
    {
        private Action<DbContextOptionsBuilder> _dbContextOptions;

        public DatabaseConfigurationSource(Action<DbContextOptionsBuilder> buidler)
        {
            this._dbContextOptions = buidler;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new DatabaseConfigurationProvider(_dbContextOptions);
        }
    }
}