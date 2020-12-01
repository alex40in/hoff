using System.Linq;
using Hoff.Application.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hoff.WebAPI.WebAPI.Common.Installers
{
    public class PresenterInstaller : IInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            typeof(Startup).Assembly.ExportedTypes
           .Where(x => !x.IsInterface && !x.IsAbstract && x.FullName.EndsWith(".Presenter"))
           .ToList()
           .ForEach(x => services.AddScoped(x));
        }
    }
}
