using AutoMapper;
using FootBallWeb.Domain.Entities;
using FootBallWeb.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.IService;
using WebApplicationFootBall.Business.Dtos.CreateDtos;
using WebApplicationFootBall.Business.Dtos.ReadDtos;
using WebApplicationFootBall.Business.Dtos.UpdateDto;

namespace WebAPI.Application.Service
{
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CountryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public CountryPostRequestDto CreateNewCountryDto(CountryPostRequestDto countryCreateDto)
        {
            var country = _mapper.Map<Country>(countryCreateDto);
            _unitOfWork.Country.Add(country);
            _unitOfWork.Save();
            var countryDtoResult = _mapper.Map<CountryPostRequestDto>(country);
            return countryDtoResult;
        }
        public List<StadiumPlayerDetailDto> GetAllCountryDtos()
        {
            var countryList = _unitOfWork.Country;
            if (countryList != null)
            {
                var country = countryList
                    .GetQuery()
                    .Include(x => x.Stadiums)
                    .Include(x => x.Players)
                    .Where(x => x.Stadiums != null && x.Players != null)
                    .ToList();
                var listCountryDto = _mapper.Map<List<StadiumPlayerDetailDto>>(country);
                return listCountryDto;
            }
            return null;
        }
        public CountryGetResponseDto GetCountryByIdDto(int id)
        {
            var country = _unitOfWork.Country.GetById(id);
            if (country != null)
            {
                var countryDto = _mapper.Map<CountryGetResponseDto>(country);
                return countryDto;
            }
            return null;
        }
        public CountryPutRequestDto UpdateCountryDto(int id, CountryPutRequestDto countryUpdateDto)
        {
            var checkCountry = _unitOfWork.Country.GetById(id);
            if (checkCountry != null)
            {
                _mapper.Map(countryUpdateDto, checkCountry);
                _unitOfWork.Save();

                var updatedCountryDto = _mapper.Map<CountryPutRequestDto>(checkCountry);
                return updatedCountryDto;
            }
            return null;
        }
    }
}
