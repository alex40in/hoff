using Hoff.Application.Common;

namespace Hoff.WebAPI.Curs
{
    public class CursRequest
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string ValuteCode { get; set; }
        internal decimal Radius => CalculateRaduisHandler.Calculate(X, Y);
    }
}
