using FootBallWeb.Domain.Interfaces;
using MediatR;

namespace WebApplicationFootBall.v2.Application.Commands.CountryCommands
{
    public class CountryDeleteCommand : IRequest<bool>
    {
        public int CountryId { get; set; }
    }
    public class CountryDeleteCommandHandler : IRequestHandler<CountryDeleteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
      
        public CountryDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CountryDeleteCommand command, CancellationToken cancellationToken)
        {
            var checkCountry = await _unitOfWork.Country.GetByIdAsync(command.CountryId);
            if (checkCountry != null)
            {
                if (checkCountry.Stadiums.Count == 0 && checkCountry.Players.Count == 0)
                {
                    _unitOfWork.Country.Remove(checkCountry);
                    _unitOfWork.Save();
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
