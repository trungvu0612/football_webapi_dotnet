using AutoMapper;
using FootBallWeb.Domain.Interfaces;
using MediatR;
using WebApplicationFootBall.Business.Dtos.UpdateDtos;

namespace WebApplicationFootBall.v2.Application.Commands.PlayerCommands
{
    public class PlayerPutCommand : PlayerPutRequestDto, IRequest<PlayerPutRequestDto>
    {
        public int PlayerId { get; set; }
    }
    public class PlayerPutCommandHandle : IRequestHandler<PlayerPutCommand, PlayerPutRequestDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PlayerPutCommandHandle(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PlayerPutRequestDto> Handle(PlayerPutCommand command, CancellationToken cancellationToken)
        {
            var checkPlayer = await _unitOfWork.Player.GetByIdAsync(command.PlayerId);
            if (checkPlayer != null)
            {
                _mapper.Map(command, checkPlayer);
                _unitOfWork.Save();

                var updatedPlayerDto = _mapper.Map<PlayerPutRequestDto>(checkPlayer);
                return updatedPlayerDto;
            }
            return null;
        }
    }
}
