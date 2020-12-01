using System.Collections.Generic;
using System.Linq;
using Hoff.Application.CbRf.GetCursOnDate;
using Microsoft.AspNetCore.Mvc;

namespace Hoff.WebAPI.Curs
{
    public class Presenter
    {
        public IActionResult ViewModel { get; internal set; }

        public void Populate(IEnumerable<GetCursOnDateResultItem> output)
        {
            var response = Map(output);
            if (response == null || response.Curses == null || !response.Curses.Any())
            {
                ViewModel = new NotFoundResult();
            }
            else
            {
                ViewModel = new OkObjectResult(output);
            }
        }

        private Response Map(IEnumerable<GetCursOnDateResultItem> output)
        {
            if (!output.Any()) return null;
            return new Response
            {
                CursDate = output.First().Curs.Date,
                Curses = output.Select(c => new ValuteCursItem
                {
                    Code = c.Valute.Code,
                    Curs = c.Curs.Curs,
                    Id = c.Valute.Id,
                    Name = c.Valute.Name,
                    Quantity = c.Curs.Quantity
                })
            };
        }

    }
}