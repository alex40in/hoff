using System;

namespace Hoff.Application.Common
{
    public static class CalculateRaduisHandler
    {
        public static decimal Calculate(int x, int y)
        {
            return (decimal)Math.Sqrt(x * x + y * y);
        }
    }
}
