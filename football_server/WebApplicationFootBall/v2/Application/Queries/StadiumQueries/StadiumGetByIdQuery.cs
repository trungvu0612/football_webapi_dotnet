using AutoMapper;
using FootBallWeb.Domain.Interfaces;
using MediatR;
using WebApplicationFootBall.Business.Dtos.ReadDtos;

namespace WebApplicationFootBall.v2.Application.Queries.StadiumQueries
{
    public class StadiumGetByIdQuery : IRequest<StadiumGetResponseDto>
    {
        public int StadiumId { get; set; }
    }
    public class StadiumGetByIdQueryHandler : IRequestHandler<StadiumGetByIdQuery, StadiumGetResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StadiumGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<StadiumGetResponseDto> Handle(StadiumGetByIdQuery query, CancellationToken cancellationToken)
        {
            var stadium = await _unitOfWork.Stadium.GetByIdAsync(query.StadiumId);
            var res = _mapper.Map<StadiumGetResponseDto>(stadium);
            return await Task.FromResult(res);
        }
    }
}
