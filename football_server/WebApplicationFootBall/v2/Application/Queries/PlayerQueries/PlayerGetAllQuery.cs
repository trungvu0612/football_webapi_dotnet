using AutoMapper;
using FootBallWeb.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplicationFootBall.Business.Dtos.ReadDtos;

namespace WebApplicationFootBall.v2.Application.Queries.PlayerQueries
{
    public class PlayerGetAllQuery : IRequest<List<ClubCountryDetailPlayerDto>>
    {
    }
    public class PlayerGetAllQueryHandle : IRequestHandler<PlayerGetAllQuery, List<ClubCountryDetailPlayerDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PlayerGetAllQueryHandle(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ClubCountryDetailPlayerDto>> Handle(PlayerGetAllQuery query, CancellationToken cancellationToken)
        {
            var checkPlayer = _unitOfWork.Player;
            if (checkPlayer != null)
            {
                var listPlayer = await checkPlayer
                    .GetQuery()
                    .Include(x => x.Country)
                    .Include(x => x.Club)
                    .ToListAsync();
                var res = _mapper.Map<List<ClubCountryDetailPlayerDto>>(listPlayer);
                return await Task.FromResult(res);
            }
            return null;
        }
    }
}
