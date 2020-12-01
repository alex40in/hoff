using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hoff.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Options;

namespace Hoff.Application.CbRf.GetCursOnDate
{
    public class GetCursOnDateQueryHandler : IRequestHandler<GetCursOnDateQuery, IEnumerable<GetCursOnDateResultItem>>
    {
        private readonly IGetCursOnDate _repository;
        private readonly CbRfCurseSettings _settings;

        public GetCursOnDateQueryHandler(IGetCursOnDate repository, IOptions<CbRfCurseSettings> options) =>
            (_repository, _settings) = (repository, options.Value);

        public async Task<IEnumerable<GetCursOnDateResultItem>> Handle(GetCursOnDateQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetCursOnDateAsync(request.Date, cancellationToken);

            if (!result.Any()) return result;

            var valutaCode = request.ValuteCode ?? _settings.ValuteCode;
            
            if (!string.IsNullOrWhiteSpace(valutaCode))
                return result.Where(c=>c.Valute.Code.Equals(valutaCode, StringComparison.OrdinalIgnoreCase));
            
            return result;
        }

    }
}
