using WebApplicationFootBall.Business.Dtos.CreateDtos;
using WebApplicationFootBall.Business.Dtos.ReadDtos;
using WebApplicationFootBall.Business.Dtos.UpdateDtos;

namespace WebApplicationFootBall.Business.IService
{
    public interface IClubService
    {
        ClubPostRequestDto CreateNewClubDto(ClubPostRequestDto clubCreateDto);
        List<StadiumPlayerDetailClubDto> GetAllClubDtos();
        ClubGetResponseDto GetClubByIdDto(int id);
        ClubPutRequestDto UpdateClubDto(int id, ClubPutRequestDto clubUpdateDto);
    }
}
