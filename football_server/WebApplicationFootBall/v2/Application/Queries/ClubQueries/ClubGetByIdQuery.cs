using AutoMapper;
using Dapper;
using FootBallWeb.Domain.Entities;
using MediatR;
using Microsoft.Data.SqlClient;
using WebApplicationFootBall.Business.Dtos.ReadDtos;

namespace WebApplicationFootBall.v2.Application.Queries.ClubQueries
{
    public class ClubGetByIdQuery : IRequest<ClubGetResponseDto>
    {
        public int ClubId { get; set; }
    }
    public class ClubGetByIdQueryHandler : IRequestHandler<ClubGetByIdQuery, ClubGetResponseDto>
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly string _connectionString;
        public ClubGetByIdQueryHandler(IMapper mapper, IConfiguration configuration)
        {
            //_unitOfWork = unitOfWork;
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("Default");
        }
        public async Task<ClubGetResponseDto> Handle(ClubGetByIdQuery query, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string checkClub = "SELECT * FROM Clubs WHERE Id = @Id";
                var club = await connection.QueryFirstOrDefaultAsync<Club>(checkClub, new { Id = query.ClubId });
                if (club != null)
                {
                    var listClubDto = _mapper.Map<ClubGetResponseDto>(club);
                    return listClubDto;
                }
                return null;
            }
            //var club = await _unitOfWork.Club.GetByIdAsync(query.ClubId);
            //var res = _mapper.Map<ClubGetResponseDto>(club);
            //return await Task.FromResult(res);
        }
    }
}
