using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Hoff.Application.Common.Interfaces;
using Hoff.Domain.Entity.CbRf;
using Hoff.Infrastructure.SoapEndpoints.CbRf;
using Microsoft.Extensions.Logging;
using static Hoff.Infrastructure.SoapEndpoints.CbRf.EnumValuteData;

namespace Hoff.Infrastructure.CbRf
{
    public class CbRfValutesRepository : IGetValutes
    {
        private readonly ICbRfClient _client;
        private readonly ILogger<CbRfValutesRepository> _logger;

        public CbRfValutesRepository(CbRfClientFactory clientFactory, ILogger<CbRfValutesRepository> logger)
        {
            _client = clientFactory.Create();
            _logger = logger;
        }

        public async Task<IEnumerable<ValuteEntity>> GetValutesAsync(CancellationToken cancellationToken)
        {
            var response = await _client.EnumValutesAsync(true);

            var resultQuery = GetValuteData(response);
            if (resultQuery == null) return Array.Empty<ValuteEntity>();

            var retVal = new List<ValuteEntity>();
            foreach (EnumValutesRow row in resultQuery.EnumValutes.Rows)
            {
                try
                {
                    retVal.Add(new ValuteEntity(row.VnumCode, row.Vname.Trim(), row.VcharCode));
                }
                catch (Exception ex)
                {
                    _logger.LogError("Create ValuteEntity error", ex);
                }
            }

            return retVal;
        }

        private EnumValuteData GetValuteData(ArrayOfXElement elements)
        {
            if (elements == null || elements.Nodes == null || elements.Nodes.Count < 2) return null;
            var data = new EnumValuteData();
            using var ms = new MemoryStream();
            using var writer = XmlWriter.Create(ms);


            elements.Nodes[1].WriteTo(writer);
            writer.Flush();
            writer.Close();
            ms.Position = 0;
            using var reader = XmlReader.Create(ms);
            data.ReadXml(reader);
            reader.Close();
            return data;
        }
    }
}
