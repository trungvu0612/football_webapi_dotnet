using Dapper;
using FootBallWeb.Domain.Entities;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationFootBall.v2.Application.Commands.ClubCommands
{
    public class ClubDeleteCommand : IRequest<bool>
    {
        public int ClubId { get; set; }
    }
    public class ClubDeleteCommandHandle : IRequestHandler<ClubDeleteCommand, bool>
    {
        private readonly string _connectionString;
        public ClubDeleteCommandHandle(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public async Task<bool> Handle(ClubDeleteCommand command, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string checkClub = "SELECT * FROM Clubs WHERE Id = @Id";
                var club = await connection.QueryAsync<Club>(checkClub, new { Id = command.ClubId });
                if (club != null)
                {
                    string deleteClub = "DELETE FROM Clubs WHERE Id = @Id";
                    await connection.ExecuteAsync(deleteClub, new { Id = command.ClubId });
                    return true;
                }
                return false;
            }
            //var checkClub = await _unitOfWork.Club
            //    .GetQuery()
            //    .Include(x => x.Players)
            //    .FirstOrDefaultAsync(X => X.Id == command.ClubId);
            //if (checkClub != null)
            //{
            //    if (checkClub.Players.Count == 0)
            //    {
            //        _unitOfWork.Club.Remove(checkClub);
            //        _unitOfWork.Save();
            //        return true;
            //    }
            //    return false;
            //}
            //return false;
        }
    }
}
