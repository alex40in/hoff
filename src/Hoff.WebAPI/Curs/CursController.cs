using System.Threading.Tasks;
using Hoff.Application.CbRf.GetCursDate;
using Hoff.Application.CbRf.GetCursOnDate;
using Hoff.WebAPI.WebAPI.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hoff.WebAPI.Curs
{
    public class CursController : ApiController
    {
        private readonly Presenter _presenter;

        public CursController(Presenter presenter) => (_presenter) = (presenter);

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType(typeof(Response))]
        [HttpGet()]
        public async Task<IActionResult> ValidateCtnAsync([FromQuery] CursRequest request)
        {
            var date = await Mediator.Send(new GetCursDateQuery { X = request.X, Y = request.Y, });

            var output = await Mediator.Send(new GetCursOnDateQuery
            {
                Date = date,
                ValuteCode = request.ValuteCode
            });
            _presenter.Populate(output);
            return _presenter.ViewModel;
        }
    }
}
