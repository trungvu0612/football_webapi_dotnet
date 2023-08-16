using FluentValidation;
using WebApplicationFootBall.Business.Dtos.CreateDtos;

namespace WebApplicationFootBall.Validation
{
    public class PlayerValidator : AbstractValidator<PlayerPostRequestDto>
    {
        public PlayerValidator()
        {
            RuleFor(player => player.Name)
           .NotEmpty().WithMessage("Tên của cầu thủ không được để trống.")
           .Must(name => name != "string").WithMessage("Tên không được là 'string'");
        }
    }
}
