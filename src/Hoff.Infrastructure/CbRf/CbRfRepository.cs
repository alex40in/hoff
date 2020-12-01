using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Hoff.Application.CbRf.GetCursOnDate;
using Hoff.Application.Common.Interfaces;
using Hoff.Domain.Entity.CbRf;
using Hoff.Infrastructure.SoapEndpoints.CbRf;
using static Hoff.Infrastructure.SoapEndpoints.CbRf.ValuteData;

namespace Hoff.Infrastructure.CbRf
{
    public class CbRfRepository : IGetCursOnDate
    {
        private readonly ICbRfClient _client;

        public CbRfRepository(CbRfClientFactory clientFactory)
        {
            _client = clientFactory.Create();
        }

        public async Task<IEnumerable<GetCursOnDateResultItem>> GetCursOnDateAsync(DateTime date, CancellationToken cancellationToken)
        {
            var response = await _client.GetCursOnDateAsync(date);
            
            var cursDate = GetCursDate(response);
            if (cursDate == null) return Array.Empty<GetCursOnDateResultItem>();

            var resultQuery = GetValuteData(response);
            if (resultQuery == null) return Array.Empty<GetCursOnDateResultItem>();

            var retVal = new List<GetCursOnDateResultItem>();
            foreach (ValuteCursOnDateRow row in resultQuery.ValuteCursOnDate.Rows)
            {
                retVal.Add(new GetCursOnDateResultItem
                {
                    Curs = new ValuteCursEntity(row.Vcode, row.Vnom, row.Vcurs, cursDate.Value),
                    Valute = new ValuteEntity(row.Vcode, row.Vname.Trim(), row.VchCode)
                });
            }

            return retVal;
        }

        private ValuteData GetValuteData(ArrayOfXElement elements)
        {
            if (elements == null || elements.Nodes == null || elements.Nodes.Count < 2) return null;
            var data = new ValuteData();
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

        private DateTime? GetCursDate(ArrayOfXElement elements)
        {
            if (elements == null || elements.Nodes == null || elements.Nodes.Count < 2) return null;

            var dateString = ((XElement)elements.Nodes[0].FirstNode)?.LastAttribute?.Value;

            if (DateTime.TryParseExact(dateString, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out var date))
            {
                return date;
            }

            return null;
        }
    }
}
