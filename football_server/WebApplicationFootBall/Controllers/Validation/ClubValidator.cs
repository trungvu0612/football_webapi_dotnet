using FluentValidation;
using WebApplicationFootBall.Business.Dtos.CreateDtos;

namespace WebApplicationFootBall.Validation
{
    public class ClubValidator : AbstractValidator<ClubPostRequestDto>
    {
        public ClubValidator()
        {
            RuleFor(club => club.Name)
                .NotEmpty().WithMessage("Tên của câu lạc bộ không được để trống.")
                .Must(name => name != "string").WithMessage("Tên không được là 'string'");
        }
    }
}
