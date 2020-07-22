using System;
using System.Linq;
using HotelZ.Core.Configuration.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Initializer.Core
{
    public class CoreServiceInitializer : BaseInitializer
    {
        protected override void Execute()
        {
            try
            {
                ServiceCollection.AddControllersWithViews();

                var x = AppDomain.CurrentDomain;

                var partialStartups = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(asb => asb.FullName.StartsWith("HotelZ.Core"))
                    .SelectMany(asb => asb.GetTypes())
                    .Where(t => !t.IsInterface && !t.IsAbstract && typeof(IPartialStartup).IsAssignableFrom(t)).ToList();

                partialStartups.ForEach(s => ((IPartialStartup)Activator.CreateInstance(s))?.ConfigureServices(ServiceCollection, Configuration));
            }
            catch
            {
                throw new InvalidOperationException("Can not initialize core services");
            }
        }
    }
}