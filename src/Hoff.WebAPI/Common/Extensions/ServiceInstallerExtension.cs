using System;
using System.Collections.Generic;
using System.Linq;
using Hoff.Application.Common;
using Hoff.Application.Exceptions;
using Hoff.Infrastructure.CbRf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hoff.WebAPI.WebAPI.Extensions
{
    public static class ServiceInstallerExtension
    {
        public static IServiceCollection InstallServicesByAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = new List<IInstaller>();
            
            var apiInstallers = typeof(Startup).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>().ToList();
 
            var applicationInstallers = typeof(ValidationException).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>().ToList();

            var infrastructureInstallers = typeof(CbRfInstaller).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>().ToList();


            installers.AddRange(apiInstallers);

            installers.AddRange(applicationInstallers);

            installers.AddRange(infrastructureInstallers);

            installers.ForEach(x => x.Install(services, configuration));

            return services;
        }
    }
}
