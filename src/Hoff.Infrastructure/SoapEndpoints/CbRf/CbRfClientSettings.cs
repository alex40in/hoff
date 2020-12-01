using System.ServiceModel;

namespace Hoff.Infrastructure.SoapEndpoints.CbRf
{
    public class CbRfClientSettings
    {
        public const string SectionName = "CbRfClientSettings";

        public string Address { get; set; }
        
        public BasicHttpBinding Binding { get; set; }
    }
}