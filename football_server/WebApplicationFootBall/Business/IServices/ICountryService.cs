using WebApplicationFootBall.Business.Dtos.CreateDtos;
using WebApplicationFootBall.Business.Dtos.ReadDtos;
using WebApplicationFootBall.Business.Dtos.UpdateDto;

namespace WebAPI.Application.IService
{
    public interface ICountryService
    {
        CountryPostRequestDto CreateNewCountryDto(CountryPostRequestDto countryCreateDto);
        List<StadiumPlayerDetailDto> GetAllCountryDtos();
        CountryGetResponseDto GetCountryByIdDto(int id);
        CountryPutRequestDto UpdateCountryDto(int id, CountryPutRequestDto countryUpdateDto);
    }
}
