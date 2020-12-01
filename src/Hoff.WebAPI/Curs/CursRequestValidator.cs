using FluentValidation;
using Hoff.Application.CbRf;
using Microsoft.Extensions.Options;

namespace Hoff.WebAPI.Curs
{
    public class CursRequestValidator: AbstractValidator<CursRequest>
    {
        public CursRequestValidator(IOptions<CbRfCurseSettings> options)
        {
            var settings = options.Value;

            RuleFor(c => c.Radius)
              .Must(x => x <= settings.Radius).OnFailure((c)=> throw new RadiusInvalidException());
        }
    }
}
