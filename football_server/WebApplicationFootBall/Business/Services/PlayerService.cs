using AutoMapper;
using FootBallWeb.Domain.Entities;
using FootBallWeb.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApplicationFootBall.Business.Dtos.CreateDtos;
using WebApplicationFootBall.Business.Dtos.ReadDtos;
using WebApplicationFootBall.Business.Dtos.UpdateDtos;
using WebApplicationFootBall.Business.IService;

namespace WebApplicationFootBall.Business.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PlayerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public PlayerPostRequestDto CreateNewPlayerDto(PlayerPostRequestDto playerCreateDto)
        {
            var player = _mapper.Map<Player>(playerCreateDto);
            _unitOfWork.Player.Add(player);
            _unitOfWork.Save();
            var playerDtoResult = _mapper.Map<PlayerPostRequestDto>(player);
            return playerDtoResult;
        }
        public List<ClubCountryDetailPlayerDto> GetAllPlayerDtos()
        {
            var playerList = _unitOfWork.Player;
            if (playerList != null)
            {
                var playerDetail = playerList
                    .GetQuery()
                    .Include(x => x.Club)
                    .Include(x => x.Country)
                    .Where(x => x.Club != null && x.Country != null)
                    .ToList();
                var listPlayerDto = _mapper.Map<List<ClubCountryDetailPlayerDto>>(playerDetail);
                return listPlayerDto;
            }
            return null;
        }
        public PlayerGetResponseDto GetPlayerByIdDto(int id)
        {
            var player = _unitOfWork.Player.GetById(id);
            if (player != null)
            {
                var playerDto = _mapper.Map<PlayerGetResponseDto>(player);
                return playerDto;
            }
            return null;
        }
        public PlayerPutRequestDto UpdatePlayerDto(int id, PlayerPutRequestDto playerUpdateDto)
        {
            var checkPlayer = _unitOfWork.Player.GetById(id);
            if (checkPlayer != null)
            {
                _mapper.Map(playerUpdateDto, checkPlayer);
                _unitOfWork.Save();

                var updatedPlayerDto = _mapper.Map<PlayerPutRequestDto>(checkPlayer);
                return updatedPlayerDto;
            }
            return null;
        }
    }
}
