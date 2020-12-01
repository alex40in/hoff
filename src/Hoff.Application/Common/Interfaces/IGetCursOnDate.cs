using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hoff.Application.CbRf.GetCursOnDate;

namespace Hoff.Application.Common.Interfaces
{
    public interface IGetCursOnDate
    {
        Task<IEnumerable<GetCursOnDateResultItem>> GetCursOnDateAsync(DateTime date, CancellationToken cancellationToken);
    }
}
