using FluentValidation;
using WebApplicationFootBall.v2.Application.Commands.ClubCommands;

namespace WebApplicationFootBall.v2.ValidationV2
{
    public class ClubValidator : AbstractValidator<ClubPostCommand>
    {
        public ClubValidator()
        {
            RuleFor(club => club.Name)
                .NotEmpty().WithMessage("Tên của câu lạc bộ không được để trống.")
                .Must(name => name != "string").WithMessage("Tên không được là 'string'");
        }
    }
}
