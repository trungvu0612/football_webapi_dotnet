using AutoMapper;
using FootBallWeb.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplicationFootBall.Business.Dtos.ReadDtos;

namespace WebApplicationFootBall.v2.Application.Queries.CountryQueries
{
    public class CountryGetAllQuery : IRequest<List<StadiumPlayerDetailDto>> { }
    public class CountryGetAllQueryHandler : IRequestHandler<CountryGetAllQuery, List<StadiumPlayerDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CountryGetAllQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<StadiumPlayerDetailDto>> Handle(CountryGetAllQuery query, CancellationToken cancellationToken)
        {
            var countryList = _unitOfWork.Country;
            if (countryList != null)
            {
                var country = await countryList
                    .GetQuery()
                    .Include(x => x.Stadiums)
                    .Include(x => x.Players)
                    .Where(x => x.Stadiums != null && x.Players != null)
                    .ToListAsync();
                var listCountryDto = _mapper.Map<List<StadiumPlayerDetailDto>>(country);
                return await Task.FromResult(listCountryDto);
            }
            return null;
        }
    }
}
