using System.Collections.Generic;
using Hoff.Domain.Entity.CbRf;
using MediatR;

namespace Hoff.Application.CbRf.GetValutes
{
    public class GetValutesQuery :  IRequest<IEnumerable<ValuteEntity>>
    {
    }
}
