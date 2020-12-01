using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hoff.Application.Common.Interfaces;
using Hoff.Domain.Entity.CbRf;
using MediatR;

namespace Hoff.Application.CbRf.GetValutes
{
    public class GetValutesQueryHandler : IRequestHandler<GetValutesQuery, IEnumerable<ValuteEntity>>
    {
        private readonly IGetValutes _valutes;

        public GetValutesQueryHandler(IGetValutes valutes) => (_valutes) = (valutes);

        public Task<IEnumerable<ValuteEntity>> Handle(GetValutesQuery request, CancellationToken cancellationToken)
        {
            return _valutes.GetValutesAsync(cancellationToken);
        }
    }
}
