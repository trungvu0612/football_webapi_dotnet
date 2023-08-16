using FluentValidation;
using WebApplicationFootBall.v2.Application.Commands.StadiumCommands;

namespace WebApplicationFootBall.v2.ValidationV2
{
    public class StadiumValidatorV2
    {
        public class StadiumValiditor : AbstractValidator<StadiumPostCommand>
        {
            public StadiumValiditor()
            {
                RuleFor(stadium => stadium.Name)
                .NotEmpty().WithMessage("Tên của sân vận động không được để trống.")
                .Must(name => name != "string").WithMessage("Tên không được là 'string'");
                RuleFor(stadium => stadium.Capacity)
                    .GreaterThan(0).WithMessage("Sức chứa của sân vận động phải lớn hơn 0.");
                RuleFor(stadium => stadium.BuiltYear)
                    .Must(year => year >= 1900 && year <= DateTime.Now.Year).WithMessage("Năm xây dựng không hợp lệ.");
                RuleFor(stadium => stadium.PitchLength)
                    .GreaterThan(0).WithMessage("Độ dài sân bóng phải lớn hơn 0.");
                RuleFor(stadium => stadium.PitchWidth)
                    .GreaterThan(0).WithMessage("Độ rộng sân bóng phải lớn hơn 0.");
                RuleFor(stadium => stadium.Phone)
                    .NotEmpty().WithMessage("Số điện thoại không được để trống.")
                    .Matches(@"^[0-9]+$").WithMessage("Số điện thoại không hợp lệ.");
                RuleFor(stadium => stadium.AddressLine1)
                    .NotEmpty().WithMessage("Địa chỉ (Dòng 1) không được để trống.")
                    .MaximumLength(100).WithMessage("Địa chỉ (Dòng 1) không vượt quá 100 ký tự.");
                RuleFor(stadium => stadium.AddressLine2)
                    .MaximumLength(100).WithMessage("Địa chỉ (Dòng 2) không vượt quá 100 ký tự.");
                RuleFor(stadium => stadium.AddressLine3)
                    .MaximumLength(100).WithMessage("Địa chỉ (Dòng 3) không vượt quá 100 ký tự.");
                RuleFor(stadium => stadium.City)
                    .NotEmpty().WithMessage("Thành phố không được để trống.")
                    .MaximumLength(100).WithMessage("Thành phố không vượt quá 100 ký tự.");
                RuleFor(stadium => stadium.PostalCode)
                    .MaximumLength(20).WithMessage("Mã bưu điện không vượt quá 20 ký tự.");
            }
        }
    }
}
