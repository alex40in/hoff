using Hoff.Application.Common;
using Hoff.Application.Common.Interfaces;
using Hoff.Infrastructure.SoapEndpoints.CbRf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hoff.Infrastructure.CbRf
{
    public class CbRfInstaller : IInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions()
                .Configure<CbRfClientSettings>(configuration.GetSection(CbRfClientSettings.SectionName));
            
            services.AddSingleton<CbRfClientFactory>();
            services.AddScoped<IGetCursOnDate,CbRfRepository>();
            services.AddScoped<IGetValutes, CbRfValutesRepository>();
        }
    }
}
