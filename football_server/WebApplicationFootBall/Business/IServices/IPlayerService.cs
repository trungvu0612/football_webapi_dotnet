using WebApplicationFootBall.Business.Dtos.CreateDtos;
using WebApplicationFootBall.Business.Dtos.ReadDtos;
using WebApplicationFootBall.Business.Dtos.UpdateDtos;

namespace WebApplicationFootBall.Business.IService
{
    public interface IPlayerService
    {
        PlayerPostRequestDto CreateNewPlayerDto(PlayerPostRequestDto playerCreateDto);
        List<ClubCountryDetailPlayerDto> GetAllPlayerDtos();
        PlayerGetResponseDto GetPlayerByIdDto(int id);
        PlayerPutRequestDto UpdatePlayerDto(int id, PlayerPutRequestDto playerUpdateDto);
    }
}
