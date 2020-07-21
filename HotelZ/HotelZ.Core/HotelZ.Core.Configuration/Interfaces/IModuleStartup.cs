using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace HotelZ.Core.Configuration.Interfaces
{
    public interface IModuleStartup : IPartialStartup
    {
        void RegisterController(IServiceProvider serviceProvider);
    }
}
