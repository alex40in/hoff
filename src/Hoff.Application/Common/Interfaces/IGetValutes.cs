using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hoff.Domain.Entity.CbRf;

namespace Hoff.Application.Common.Interfaces
{
    public interface IGetValutes
    {
        Task<IEnumerable<ValuteEntity>> GetValutesAsync(CancellationToken cancellationToken);
    }
}
