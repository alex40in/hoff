using Hoff.Application.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hoff.Application.CbRf
{
    public class CbRfCurseInstaller : IInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions()
                .Configure<CbRfCurseSettings>(configuration.GetSection(CbRfCurseSettings.SectionName));
        }
    }
}
