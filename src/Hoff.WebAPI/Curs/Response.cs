using System;
using System.Collections.Generic;

namespace Hoff.WebAPI.Curs
{
    public class Response
    {
        public DateTime CursDate { get; set; }
        public IEnumerable<ValuteCursItem> Curses { get; set; }
    }
}
