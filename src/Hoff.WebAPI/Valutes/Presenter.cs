using System.Collections.Generic;
using System.Linq;
using Hoff.Domain.Entity.CbRf;
using Microsoft.AspNetCore.Mvc;

namespace Hoff.WebAPI.Valutes
{
    public class Presenter
    {
        public IActionResult ViewModel { get; internal set; }

        public void Populate(IEnumerable<ValuteEntity> output)
        {
            var response = Map(output);
            if (response == null || !response.Any())
            {
                ViewModel = new NotFoundResult();
            }
            else
            {
                ViewModel = new OkObjectResult(output);
            }
        }

        private IEnumerable<ValuteItemResponse> Map(IEnumerable<ValuteEntity> output)
        {
            if (!output.Any()) return null;
            return output.Select(c => new ValuteItemResponse
            {
                Code = c.Code,
                Id = c.Id,
                Name = c.Name,
            });
        }
    }
}