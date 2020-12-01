using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Hoff.Application.CbRf.GetCursDate
{
    public class GetCursDateQueryHandler : IRequestHandler<GetCursDateQuery, DateTime>
    {
        public Task<DateTime> Handle(GetCursDateQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(GetDate(request.X, request.Y));
        }

        protected DateTime GetDate(int x, int y)
        {
            var retval = (x >= 0, y >= 0) switch
            {
                (true, true) => DateTime.Now.Date,
                (false, true) => DateTime.Now.Date.AddDays(-1),
                (false, false) => DateTime.Now.Date.AddDays(-2),
                (true, false) => DateTime.Now.Date.AddDays(1)
            };
            return retval;
        }
    }
}
