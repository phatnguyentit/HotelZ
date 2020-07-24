using System;
using System.Linq;
using HotelZ.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Initializer.Core
{
    public class CoreInitializer : BaseInitializer
    {
        protected override void Execute()
        {
            try
            {
                ServiceCollection.AddControllersWithViews();

                var partialStartups = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(asb => asb.FullName.StartsWith("HotelZ.Core"))
                    .SelectMany(asb => asb.GetTypes())
                    .Where(t => !t.IsInterface && !t.IsAbstract && typeof(IPartialStartup).IsAssignableFrom(t)).ToList();

                if (partialStartups.Count == 0)
                {
                    throw new InvalidOperationException("There is no startup for core assemblies");
                }

                partialStartups.ForEach(s => ((IPartialStartup)Activator.CreateInstance(s))?.ConfigureServices(ServiceCollection, Configuration));
            }
            catch
            {
                throw new InvalidOperationException("Can not initialize core asseblies");
            }
        }
    }
}