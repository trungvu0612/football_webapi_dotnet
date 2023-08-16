using FluentValidation;
using WebApplicationFootBall.v2.Application.Commands.PlayerCommands;

namespace WebApplicationFootBall.v2.ValidationV2
{
    public class PlayerValidator : AbstractValidator<PlayerPostCommand>
    {
        public PlayerValidator()
        {
            RuleFor(player => player.Name)
                 .NotEmpty().WithMessage("Tên của cầu thủ không được để trống.")
                 .Must(name => name != "string").WithMessage("Tên không được là 'string'");
            RuleFor(player => player.HeightlnCm)
                .GreaterThan(0).WithMessage("Chiều cao của cầu thủ phải lớn hơn 0.");
        }
    }
}
