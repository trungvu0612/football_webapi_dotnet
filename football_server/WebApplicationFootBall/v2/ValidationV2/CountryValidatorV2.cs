using FluentValidation;
using WebApplicationFootBall.v2.Application.Commands.CountryCommands;

namespace WebApplicationFootBall.v2.ValidationV2
{
    public class CountryValidatorV2 : AbstractValidator<CountryPostCommand>
    {
        public CountryValidatorV2()
        {
            RuleFor(country => country.Name)
                    .NotEmpty().WithMessage("Tên quốc gia không được để trống.")
                    .Must(name => name != "string").WithMessage("Tên không được là 'string'");
            RuleFor(country => country.TwoLetterIsoCode)
                .NotEmpty().WithMessage("Mã quốc gia hai ký tự không được để trống.");
            RuleFor(country => country.ThreeLetterIsoCode)
                .NotEmpty().WithMessage("Mã quốc gia ba ký tự không được để trống.");
            RuleFor(country => country.DisplayOrder)
                .GreaterThan(0).WithMessage("Thứ tự hiển thị phải lớn hơn 0.");
        }
    }
}
