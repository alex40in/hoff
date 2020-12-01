using System;
using FluentAssertions;
using FluentValidation;
using FluentValidation.TestHelper;
using Hoff.Application.CbRf;
using Hoff.WebAPI.Curs;
using Microsoft.Extensions.Options;
using Xunit;

namespace Hoff.WebAPI.Unit.Test
{
    public class CursRequestValidatorTests
    {
        [Theory]
        [InlineData(1, 1, 10)]
        [InlineData(1, 2, 10)]
        [InlineData(1, 3, 10)]
        [InlineData(1, 4, 10)]
        [InlineData(1, 5, 10)]
        [InlineData(1, 7, 10)]
        [InlineData(1, 8, 10)]
        [InlineData(1, 9, 10)]
        [InlineData(1, -1, 10)]
        [InlineData(1, -2, 10)]
        [InlineData(1, -3, 10)]
        [InlineData(1, -4, 10)]
        [InlineData(1, -5, 10)]
        [InlineData(1, -7, 10)]
        [InlineData(1, -8, 10)]
        [InlineData(1, -9, 10)]
        [InlineData(-1, 1, 10)]
        [InlineData(-1, 2, 10)]
        [InlineData(-1, 3, 10)]
        [InlineData(-1, 4, 10)]
        [InlineData(-1, 5, 10)]
        [InlineData(-1, 7, 10)]
        [InlineData(-1, 8, 10)]
        [InlineData(-1, 9, 10)]
        [InlineData(-1, -1, 10)]
        [InlineData(-1, -2, 10)]
        [InlineData(-1, -3, 10)]
        [InlineData(-1, -4, 10)]
        [InlineData(-1, -5, 10)]
        [InlineData(-1, -7, 10)]
        [InlineData(-1, -8, 10)]
        [InlineData(-1, -9, 10)]
        public void ShouldNotHaveAnyValidationErrors(int x, int y, decimal radius)
        {
            var options = new OptionsWrapper<CbRfCurseSettings>(new CbRfCurseSettings { Radius = radius });
            var validator = new CursRequestValidator(options);
            var command = new CursRequest
            {
                X = x,
                Y = y
            };
            var result = validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(-1, 10, 10)]
        [InlineData(-1, -10, 10)]
        [InlineData(1, -10, 10)]
        public void ShouldHaveAnyValidationError(int x, int y, decimal radius)
        {
            var options = new OptionsWrapper<CbRfCurseSettings>(new CbRfCurseSettings { Radius = radius });
            var validator = new CursRequestValidator(options);
            var command = new CursRequest
            {
                X = x,
                Y = y
            };
            Action act = () => validator.Validate(command, options => 
            {
                options.ThrowOnFailures();
            });
            act.Should().Throw<RadiusInvalidException>();
        }
    }
}
