using System.Collections.Generic;
using System.Threading.Tasks;
using Hoff.Application.CbRf.GetValutes;
using Hoff.WebAPI.WebAPI.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hoff.WebAPI.Valutes
{
    public class ValutesController : ApiController
    {
        private readonly Presenter _presenter;

        public ValutesController(Presenter presenter) => (_presenter) = (presenter);

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType(typeof(IEnumerable<ValuteItemResponse>))]
        [HttpGet()]
        public async Task<IActionResult> GetValutesAsync()
        {
            var output = await Mediator.Send(new GetValutesQuery());
            _presenter.Populate(output);
            return _presenter.ViewModel;
        }
    }
}
