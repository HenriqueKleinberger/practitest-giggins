using FluentValidation;
using GigginsPractitestApi.Constants;
using GigginsPractitestApi.DTO;

namespace GigginsPractitestApi.Validators
{
    public class GigginDTOValidator : AbstractValidator<GigginDTO>
    {
        public GigginDTOValidator()
        {
            RuleFor(x => x.Title).Must(x => x == null || x.Length >= 2);
            RuleFor(x => x.Description).Must(x => x == null || x.Length >= 2);
            RuleFor(x => x.Price).Must(x => x >= 0).WithMessage(ErrorMessages.PRICE_MUST_BE_POSITIVE);
            RuleFor(x => x.Artist).Must(x => x == null || x.Length >= 2);
            RuleFor(x => x.Image).Must(x => x == null || x.Length >= 2);
        }
    }
}