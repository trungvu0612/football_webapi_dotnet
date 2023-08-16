using FootBallWeb.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationFootBall.v2.Application.Commands.PlayerCommands
{
    public class PlayerDeleteCommand : IRequest<bool>
    {
        public int PlayerId { get; set; }
    }
    public class PlayerDeleteCommandHandle : IRequestHandler<PlayerDeleteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlayerDeleteCommandHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(PlayerDeleteCommand command, CancellationToken cancellationToken)
        {
            var checkPlayer = await _unitOfWork.Player.GetQuery().FirstOrDefaultAsync(x => x.Id == command.PlayerId);
            if (checkPlayer != null)
            {
                _unitOfWork.Player.Remove(checkPlayer);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}
