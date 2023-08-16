using AutoMapper;
using Dapper;
using FootBallWeb.Domain.Entities;
using FootBallWeb.Domain.Interfaces;
using MediatR;
using Microsoft.Data.SqlClient;
using WebApplicationFootBall.Business.Dtos.UpdateDtos;

namespace WebApplicationFootBall.v2.Application.Commands.ClubCommands
{
    public class ClubPutCommand : ClubPutRequestDto, IRequest<ClubPutRequestDto>
    {
        public int ClubId { get; set; }
    }
    public class ClubPutCommandHandle : IRequestHandler<ClubPutCommand, ClubPutRequestDto>
    {
        private readonly IMapper _mapper;
        private readonly string _connectionString;
        public ClubPutCommandHandle(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("Default");
        }
        public async Task<ClubPutRequestDto> Handle(ClubPutCommand command, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string checkClub = "SELECT * FROM Clubs WHERE Id = @Id";
                var club = await connection.QueryFirstOrDefaultAsync<Club>(checkClub, new { Id = command.ClubId });
                if (club != null)
                {
                    // check stadium is valid
                    string queryStadium = "SELECT * FROM Stadiums WHERE Id = @StadiumId";
                    var checkStadium = await connection.QueryFirstOrDefaultAsync<Stadium>(queryStadium, new { command.StadiumId });
                    if (checkStadium != null)
                    {
                        // update data for fields in club table
                        string updateClub = "UPDATE Clubs SET Name = @Name, PhotoUrl = @PhotoUrl, FacebookUrl = @FacebookUrl, TwitterUrl =  @TwitterUrl, YoutubeUrl = @YoutubeUrl, InstagramUrl =  @InstagramUrl, WebsiteUrl =  @WebsiteUrl, StadiumId = @StadiumId, UpdatedBy = @UpdatedBy, UpdatedDate = @UpdatedDate WHERE Id = @Id";
                        _mapper.Map(command, club);

                        await connection.ExecuteAsync(updateClub, club);
                        return await Task.FromResult(command);
                    }
                    return null;
                }
                return null;
            }

            //var checkClub = await _unitOfWork.Club.GetByIdAsync(command.ClubId);
            //if (checkClub != null)
            //{
            //    _mapper.Map(command, checkClub);
            //    _unitOfWork.Save();

            //    var updatedClubDto = _mapper.Map<ClubPutRequestDto>(checkClub);
            //    return await Task.FromResult(updatedClubDto);
            //}
            //return null;
        }

    }
}
