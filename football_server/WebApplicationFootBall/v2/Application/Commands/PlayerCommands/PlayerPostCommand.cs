using AutoMapper;
using FootBallWeb.Domain.Entities;
using FootBallWeb.Domain.Interfaces;
using MediatR;
using WebApplicationFootBall.Business.Dtos.CreateDtos;

namespace WebApplicationFootBall.v2.Application.Commands.PlayerCommands
{
    public class PlayerPostCommand : PlayerPostRequestDto, IRequest<PlayerPostRequestDto>
    {
    }
    public class PlayerPostCommandHandler : IRequestHandler<PlayerPostCommand, PlayerPostRequestDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PlayerPostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PlayerPostRequestDto> Handle(PlayerPostCommand command, CancellationToken cancellationToken)
        {
            var country = _unitOfWork.Country.GetQuery().FirstOrDefault(x => x.Id == command.CountryId);
            if (country != null)
            {
                var player = _mapper.Map<Player>(command);
                player.CountryId = country.Id;
                player.Country = country;
                await _unitOfWork.Player.AddAsync(player);
                _unitOfWork.Save();
                var res = _mapper.Map<PlayerPostRequestDto>(player);
                return await Task.FromResult(res);
            }
            return null;
        }
    }
}
