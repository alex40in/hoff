using System;
using FluentAssertions;
using Hoff.Application.CbRf.GetCursDate;
using Xunit;

namespace Hoff.Application.Unit.Test
{
    public class GetCursDateQueryHandlerTests
    {
        [Fact]
        public void GetDate_Should_BeToday()
        {
            var mock = new GetCursDateQueryHandlerMosk();
            mock.GetDateFromPoint(1, 1).Should().Be(DateTime.Now.Date);
        }

        [Fact]
        public void GetDate_Should_BeYesterday()
        {
            var mock = new GetCursDateQueryHandlerMosk();
            mock.GetDateFromPoint(-1, 1).Should().Be(DateTime.Now.Date.AddDays(-1));
        }

        [Fact]
        public void GetDate_Should_BeBeforeYesterday()
        {
            var mock = new GetCursDateQueryHandlerMosk();
            mock.GetDateFromPoint(-1, -1).Should().Be(DateTime.Now.Date.AddDays(-2));        }

        [Fact]
        public void GetDate_Should_BeTomorrow()
        {
            var mock = new GetCursDateQueryHandlerMosk();
            mock.GetDateFromPoint(1, -1).Should().Be(DateTime.Now.Date.AddDays(1));
        }

        class GetCursDateQueryHandlerMosk : GetCursDateQueryHandler
        {
            public DateTime GetDateFromPoint(int x, int y)
            {
                return base.GetDate(x, y);
            }
        }
    }
}
