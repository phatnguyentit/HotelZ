using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using HotelZ.Core.Configuration;
using HotelZ.Core.Configuration.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZ.Initializer.Module
{
    public class ModuleInitializer : BaseInitializer
    {
        private readonly AssemblyLoadContext _assemblyLoadContext;

        public ModuleInitializer()
        {
            _assemblyLoadContext = new AssemblyLoadContext(AppDomain.CurrentDomain.BaseDirectory);
        }

        protected override void Execute()
        {
            try
            {
                var activeModules = Configuration.GetSection("Modules").Get<List<ModuleConfig>>()
                    .Where(m => m.Active).OrderBy(m => m.Order).ToList();

                var mvcBuilder = ServiceCollection.AddMvc().AddControllersAsServices();

                var moduleAssemblies = activeModules.Select(m =>
                {
                    var assemblyFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, m.Name.Dll());
                    var assembly = _assemblyLoadContext.LoadFromAssemblyPath(assemblyFile);
                    mvcBuilder.ConfigureApplicationPartManager(mg => mg.ApplicationParts.Add(new AssemblyPart(assembly)));

                    if (m.IsViewModule)
                    {
                        var viewAssemblyFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, m.Name.Views().Dll());
                        var viewAssembly = _assemblyLoadContext.LoadFromAssemblyPath(viewAssemblyFile);
                        mvcBuilder.ConfigureApplicationPartManager(mg => mg.ApplicationParts.Add(new CompiledRazorAssemblyPart(viewAssembly)));
                    }

                    return assembly;
                }).ToList();
                
                moduleAssemblies.ForEach(md =>
                {
                    md.GetTypes().Where(t => !t.IsInterface && typeof(BaseModuleStartup).IsAssignableFrom(t))
                        .Select(t => (BaseModuleStartup)Activator.CreateInstance(t)).ToList()
                        .ForEach(m =>
                        {
                            m.ConfigureServices(ServiceCollection, Configuration);

                            var controllers = md.GetTypes().Where(t => !t.IsInterface && typeof(Controller).IsAssignableFrom(t)).ToList();
                            m.RegisterControllers(ServiceCollection, controllers);
                        });
                });
            }
            catch
            {
                throw new InvalidOperationException("Can not initialize modules");
            }
        }

    }
}
