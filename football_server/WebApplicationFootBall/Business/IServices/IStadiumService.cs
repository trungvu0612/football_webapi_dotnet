using WebApplicationFootBall.Business.Dtos.CreateDtos;
using WebApplicationFootBall.Business.Dtos.ReadDtos;
using WebApplicationFootBall.Business.Dtos.UpdateDtos;

namespace WebApplicationFootBall.Business.IService
{
    public interface IStadiumService
    {
        StadiumPostRequestDto CreateNewStadiumDto(StadiumPostRequestDto stadiumCreateDto);
        List<CountryDetailDto> GetAllStadiumDtos();
        StadiumGetResponseDto GetStadiumByIdDto(int id);
        StadiumPutRequestDto UpdateStadiumDto(int id, StadiumPutRequestDto stadiumUpdateDto);
    }
}
