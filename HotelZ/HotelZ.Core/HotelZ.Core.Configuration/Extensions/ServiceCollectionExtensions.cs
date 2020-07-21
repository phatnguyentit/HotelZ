using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using HotelZ.Core.Configuration.Interfaces;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;

namespace HotelZ.Core.Configuration.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureHotelZServices(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            ConfigureCoreServices(services, configuration);
            ConfigureModuleServices(services, configuration);
        }

        private static void ConfigureCoreServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();

            var assemblyLoadContext = new AssemblyLoadContext(AppDomain.CurrentDomain.BaseDirectory);

            services.Configure<RazorViewEngineOptions>(opt =>
            {
                opt.AreaPageViewLocationFormats.Add(@$"/Pages/{1}/{0}{RazorViewEngine.ViewExtension}");
            });

            var partialStartups = AppDomain.CurrentDomain.GetAssemblies()
                .Where(asb => asb.FullName.StartsWith("HotelZ.Core"))
                .SelectMany(asb => asb.GetTypes())
                .Where(t => !t.IsInterface && !t.IsAbstract && typeof(IPartialStartup).IsAssignableFrom(t)).ToList();

            partialStartups.ForEach(s => ((IPartialStartup)Activator.CreateInstance(s)).ConfigureServices(services, configuration));
        }

        private static void ConfigureModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            var moduleStartConfigs = configuration.GetSection("Modules").Get<List<ModuleStartupConfig>>()
                .Where(m => m.Active)
                .OrderBy(m => m.Order).ToList();

            var mvcBuidler = services.AddMvc().AddControllersAsServices();
            var assemblyLoadContext = new AssemblyLoadContext(AppDomain.CurrentDomain.BaseDirectory);

            var modules = moduleStartConfigs.Select(m =>
            {
                var assemblyFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, m.Name);
                var assembly = assemblyLoadContext.LoadFromAssemblyPath(assemblyFile);
                mvcBuidler.ConfigureApplicationPartManager(mg => mg.ApplicationParts.Add(new AssemblyPart(assembly)));

                if (m.ViewModule != null)
                {
                    var viewAssemblyFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, m.ViewModule.Name);
                    var viewAssembly = assemblyLoadContext.LoadFromAssemblyPath(viewAssemblyFile);
                    mvcBuidler.ConfigureApplicationPartManager(mg => mg.ApplicationParts.Add(new CompiledRazorAssemblyPart(viewAssembly)));
                }

                return assembly;
            }).ToList();


            modules.ForEach(md =>
            {
                md.GetTypes().Where(t => !t.IsInterface && typeof(ModuleStartup).IsAssignableFrom(t))
                    .Select(t => (ModuleStartup)Activator.CreateInstance(t)).ToList()
                    .ForEach(m =>
                    {
                        m.ConfigureServices(services, configuration);

                        var controllers = md.GetTypes().Where(t => !t.IsInterface && typeof(Controller).IsAssignableFrom(t));
                        m.RegisterControllers(services, controllers);
                    });
            });
            var startupGroup = modules.SelectMany(m => m.GetTypes()).GroupBy(t => t.Assembly);
        }
    }
}