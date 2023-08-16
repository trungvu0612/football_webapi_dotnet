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
    public class StadiumService : IStadiumService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public StadiumService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public StadiumPostRequestDto CreateNewStadiumDto(StadiumPostRequestDto stadiumCreateDto)
        {
            var country = _unitOfWork.Country.GetQuery().FirstOrDefault(x => x.Id == stadiumCreateDto.CountryId);
            if (country != null)
            {
                var stadium = _mapper.Map<Stadium>(stadiumCreateDto);
                stadium.CountryId = country.Id;
                stadium.Country = country;
                _unitOfWork.Stadium.Add(stadium);
                _unitOfWork.Save();
                var stadiumDtoResult = _mapper.Map<StadiumPostRequestDto>(stadium);
                return stadiumDtoResult;
            }
            return null;
        }
        public List<CountryDetailDto> GetAllStadiumDtos()
        {
            var stadiumList = _unitOfWork.Stadium;
            if (stadiumList != null)
            {
                var stadium = stadiumList
                    .GetQuery()
                    .Include(x => x.Country)
                    .Where(x => x.Country != null)
                    .ToList();
                var listStadiumDto = _mapper.Map<List<CountryDetailDto>>(stadium);
                return listStadiumDto;
            }
            return null;
        }
        public StadiumGetResponseDto GetStadiumByIdDto(int id)
        {
            var stadium = _unitOfWork.Stadium.GetById(id);
            if (stadium != null)
            {
                var stadiumDto = _mapper.Map<StadiumGetResponseDto>(stadium);
                return stadiumDto;
            }
            return null;
        }
        public StadiumPutRequestDto UpdateStadiumDto(int id, StadiumPutRequestDto stadiumUpdateDto)
        {
            var checkStadium = _unitOfWork.Stadium.GetById(id);
            if (checkStadium != null)
            {
                _mapper.Map(stadiumUpdateDto, checkStadium);
                _unitOfWork.Save();

                var updatedStadiumDto = _mapper.Map<StadiumPutRequestDto>(checkStadium);
                return updatedStadiumDto;
            }
            return null;
        }
    }
}
