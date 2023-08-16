using FootBallWeb.Domain.Interfaces;
using MediatR;

namespace WebApplicationFootBall.v2.Application.Commands.StadiumCommands
{
    public class StadiumDeleteCommand : IRequest<bool>
    {
        public int StadiumId { get; set; }
    }
    public class StadiumDeleteCommandHandler : IRequestHandler<StadiumDeleteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public StadiumDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(StadiumDeleteCommand command, CancellationToken cancellationToken)
        {
            var checkStadium = await _unitOfWork.Stadium.GetByIdAsync(command.StadiumId);
            if (checkStadium != null)
            {
                if (checkStadium.Clubs.Count == 0)
                {
                    _unitOfWork.Stadium.Remove(checkStadium);
                    _unitOfWork.Save();
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
