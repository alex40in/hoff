using System;
using System.Collections.Generic;
using MediatR;

namespace Hoff.Application.CbRf.GetCursOnDate
{
    public class GetCursOnDateQuery : IRequest<IEnumerable<GetCursOnDateResultItem>>
    {
        public DateTime Date { get; set; }
        public string ValuteCode { get; set; }
    }
}
