using Dapper;
using FootBallWeb.Domain.Entities;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApplicationFootBall.Business.Dtos.CreateDtos;


namespace WebApplicationFootBall.v2.Application.Commands.ClubCommands
{
    public class ClubPostCommand : ClubPostRequestDto, IRequest<ClubPostRequestDto>
    {
    }
    public class ClubPostCommandHandler : IRequestHandler<ClubPostCommand, ClubPostRequestDto>
    {
        private readonly string _connectionString;
        public ClubPostCommandHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public async Task<ClubPostRequestDto> Handle(ClubPostCommand command, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string checkStadium = "SELECT * FROM Stadiums WHERE Id = @StadiumId";
                var parameters = new DynamicParameters();
                parameters.Add("StadiumId", command.StadiumId, DbType.Int32);
                var stadium = await connection.QueryAsync<Stadium>(checkStadium, parameters);
                if (stadium != null)
                {
                    string insertQuery = "INSERT INTO Clubs (Name, PhotoUrl, WebsiteUrl, FaceBookUrl, TwitterUrl, YoutubeUrl, InstagramUrl, StadiumId, CreatedBy, CreatedDate) " +
                                 "VALUES (@Name, @PhotoUrl, @WebsiteUrl, @FaceBookUrl, @TwitterUrl, @YoutubeUrl, @InstagramUrl, @StadiumId, @CreatedBy, @CreatedDate)";

                    await connection.ExecuteAsync(insertQuery, command);

                    return command;
                }
                //var stadium = _unitOfWork.Stadium.GetQuery().FirstOrDefault(x => x.Id == command.StadiumId);
                //if (stadium != null)
                //{
                //    var club = _mapper.Map<Club>(command);
                //    club.StadiumId = stadium.Id;
                //    club.Stadium = stadium;
                //    await _unitOfWork.Club.AddAsync(club);
                //    _unitOfWork.Save();
                //    var res = _mapper.Map<ClubPostRequestDto>(club);
                //    return await Task.FromResult(res);
                //}
                return null;
            }
        }
    }
}
