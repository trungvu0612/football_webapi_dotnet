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
    public class ClubService : IClubService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ClubService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ClubPostRequestDto CreateNewClubDto(ClubPostRequestDto clubCreateDto)
        {
            var stadium = _unitOfWork.Stadium.GetQuery().FirstOrDefault(x => x.Id == clubCreateDto.StadiumId);
            if (stadium != null)
            {
                var club = _mapper.Map<Club>(clubCreateDto);
                club.StadiumId = stadium.Id;
                club.Stadium = stadium;
                _unitOfWork.Club.Add(club);
                _unitOfWork.Save();
                var clubDtoResult = _mapper.Map<ClubPostRequestDto>(club);
                return clubDtoResult;
            }
            return null;
        }
        public List<StadiumPlayerDetailClubDto> GetAllClubDtos()
        {
            var clubList = _unitOfWork.Club;
            if (clubList != null)
            {
                var clubDetail = clubList
                   .GetQuery()
                   .Include(x => x.Stadium)
                   .Include(x => x.Players)
                   .Where(x => x.Stadium != null && x.Players != null)
                   .ToList();
                var listClubDto = _mapper.Map<List<StadiumPlayerDetailClubDto>>(clubDetail);
                return listClubDto;
            }
            return null;
        }
        public ClubGetResponseDto GetClubByIdDto(int id)
        {
            var club = _unitOfWork.Club.GetById(id);
            if (club != null)
            {
                var clubDto = _mapper.Map<ClubGetResponseDto>(club);
                return clubDto;
            }
            return null;
        }
        public ClubPutRequestDto UpdateClubDto(int id, ClubPutRequestDto clubUpdateDto)
        {
            var checkClub = _unitOfWork.Club.GetById(id);
            if (checkClub != null)
            {
                _mapper.Map(clubUpdateDto, checkClub);
                _unitOfWork.Save();

                var updatedClubDto = _mapper.Map<ClubPutRequestDto>(checkClub);
                return updatedClubDto;
            }
            return null;
        }
    }
}
