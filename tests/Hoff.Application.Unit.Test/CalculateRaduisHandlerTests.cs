using Hoff.Application.Common;
using Xunit;

namespace Hoff.Application.Unit.Test
{
    public class CalculateRaduisHandlerTests
    {
        [Fact]
        public void Test1()
        {
            var radius = CalculateRaduisHandler.Calculate(-10, -5);
        }
    }
}
