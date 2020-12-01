using System;
using MediatR;

namespace Hoff.Application.CbRf.GetCursDate
{
    public class GetCursDateQuery : IRequest<DateTime>
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
