using System;

namespace HotelZ.Core.Interfaces
{
    public interface IModuleStartup : IPartialStartup
    {
        void RegisterController(IServiceProvider serviceProvider);
    }
}
