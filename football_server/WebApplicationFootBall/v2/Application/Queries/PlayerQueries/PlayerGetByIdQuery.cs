using AutoMapper;
using FootBallWeb.Domain.Interfaces;
using MediatR;
using WebApplicationFootBall.Business.Dtos.ReadDtos;

namespace WebApplicationFootBall.v2.Application.Queries.PlayerQueries
{
    public class PlayerGetByIdQuery : IRequest<PlayerGetResponseDto>
    {
        public int PlayerId { get; set; }
    }
    public class PlayerGetByIdQueryHandler : IRequestHandler<PlayerGetByIdQuery, PlayerGetResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PlayerGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PlayerGetResponseDto> Handle(PlayerGetByIdQuery query, CancellationToken cancellationToken)
        {
            var player = await _unitOfWork.Player.GetByIdAsync(query.PlayerId);
            var res = _mapper.Map<PlayerGetResponseDto>(player);
            return await Task.FromResult(res);
        }
    }
}
