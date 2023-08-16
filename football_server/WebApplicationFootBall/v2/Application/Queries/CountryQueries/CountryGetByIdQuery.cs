using AutoMapper;
using FootBallWeb.Domain.Interfaces;
using MediatR;
using WebApplicationFootBall.Business.Dtos.ReadDtos;

namespace WebApplicationFootBall.v2.Application.Queries.CountryQueries
{
    public class CountryGetByIdQuery : IRequest<CountryGetResponseDto>
    {
        public int CountryId { get; set; }
    }
    public class CountryByIdQueryHandler : IRequestHandler<CountryGetByIdQuery, CountryGetResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CountryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CountryGetResponseDto> Handle(CountryGetByIdQuery query, CancellationToken cancellationToken)
        {
            var country = await _unitOfWork.Country.GetByIdAsync(query.CountryId);
            var res = _mapper.Map<CountryGetResponseDto>(country);
            return await Task.FromResult(res);
        }
    }
}
