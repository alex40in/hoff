using System.ServiceModel;
using Microsoft.Extensions.Options;

namespace Hoff.Infrastructure.SoapEndpoints.CbRf
{
    public class CbRfClientFactory
    {
        private readonly CbRfClientSettings _settings;

        public CbRfClientFactory(IOptions<CbRfClientSettings> options) => (_settings) = (options.Value);

        public ICbRfClient Create()
        {
            return new DailyInfoSoapClient(_settings.Binding, new EndpointAddress(_settings.Address));
        }
    }
}
