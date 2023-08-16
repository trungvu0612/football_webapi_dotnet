using AutoMapper;
using FootBallWeb.Domain.Interfaces;
using MediatR;
using WebApplicationFootBall.Business.Dtos.UpdateDto;

namespace WebApplicationFootBall.v2.Application.Commands.CountryCommands
{
    public class CountryPutCommand : CountryPutRequestDto, IRequest<CountryPutRequestDto>
    {
        public int CountryId { get; set; }
    }
    public class CountryPutCommandHanler : IRequestHandler<CountryPutCommand, CountryPutRequestDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CountryPutCommandHanler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CountryPutRequestDto> Handle(CountryPutCommand command, CancellationToken cancellationToken)
        {
            var checkCountry = await _unitOfWork.Country.GetByIdAsync(command.CountryId);
            if (checkCountry != null)
            {
                _mapper.Map(command, checkCountry);
                _unitOfWork.Save();
                var updatedCountryDto = _mapper.Map<CountryPutRequestDto>(checkCountry);
                return await Task.FromResult(updatedCountryDto);
            }
            return null;
        }
    }
}
