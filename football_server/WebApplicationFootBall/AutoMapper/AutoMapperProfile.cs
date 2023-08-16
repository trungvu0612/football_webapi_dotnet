using AutoMapper;
using FootBallWeb.Domain.Entities;
using WebApplicationFootBall.Business.Dtos.CreateDtos;
using WebApplicationFootBall.Business.Dtos.ReadDtos;
using WebApplicationFootBall.Business.Dtos.UpdateDto;
using WebApplicationFootBall.Business.Dtos.UpdateDtos;
using WebApplicationFootBall.v2.Application.Commands.ClubCommands;
using WebApplicationFootBall.v2.Application.Commands.CountryCommands;
using WebApplicationFootBall.v2.Application.Commands.PlayerCommands;
using WebApplicationFootBall.v2.Application.Commands.StadiumCommands;

namespace WebApplicationFootBall.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Read method
            CreateMap<Player, PlayerGetResponseDto>().ReverseMap();
            CreateMap<Stadium, StadiumGetResponseDto>().ReverseMap();
            CreateMap<Country, CountryGetResponseDto>().ReverseMap();
            CreateMap<Club, ClubGetResponseDto>().ReverseMap();

            // Master Data Mapping
            CreateMap<CountryDetailDto, Stadium>().ReverseMap();
            CreateMap<StadiumPlayerDetailDto, Country>().ReverseMap();
            CreateMap<StadiumPlayerDetailClubDto, Club>().ReverseMap();
            CreateMap<ClubCountryDetailPlayerDto, Player>().ReverseMap();

            //Create method
            CreateMap<Country, CountryPostRequestDto>().ReverseMap();
            CreateMap<Stadium, StadiumPostRequestDto>().ReverseMap();
            CreateMap<Club, ClubPostRequestDto>().ReverseMap();
            CreateMap<Player, PlayerPostRequestDto>().ReverseMap();

            //Update method
            CreateMap<Country, CountryPutRequestDto>().ReverseMap();
            CreateMap<Stadium, StadiumPutRequestDto>().ReverseMap();
            CreateMap<Club, ClubPutRequestDto>().ReverseMap();
            CreateMap<Player, PlayerPutRequestDto>().ReverseMap();

            // MediatR Controller V2
            //country
            CreateMap<CountryPostCommand, CountryPostRequestDto>().ReverseMap();
            CreateMap<CountryPutCommand, Country>().ReverseMap();
            CreateMap<CountryPostCommand, Country>().ReverseMap();
            //stadium
            CreateMap<StadiumPostCommand, StadiumPostRequestDto>().ReverseMap();
            CreateMap<StadiumPutCommand, Stadium>().ReverseMap();
            CreateMap<StadiumPostCommand, Stadium>().ReverseMap();
            //club
            CreateMap<ClubPostCommand, ClubPostRequestDto>().ReverseMap();
            CreateMap<ClubPostCommand, Club>().ReverseMap();
            CreateMap<ClubPutCommand, Club>().ReverseMap();
            //player
            CreateMap<PlayerPostCommand, PlayerPostRequestDto>().ReverseMap();
            CreateMap<PlayerPostCommand, Player>().ReverseMap();
            CreateMap<PlayerPutCommand, Player>().ReverseMap();
        }
    }
}

