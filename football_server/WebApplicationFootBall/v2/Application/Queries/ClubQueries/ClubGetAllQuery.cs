using AutoMapper;
using Dapper;
using FootBallWeb.Domain.Interfaces;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplicationFootBall.Business.Dtos.ReadDtos;

namespace WebApplicationFootBall.v2.Application.Queries.ClubQueries
{
    public class ClubGetAllQuery : IRequest<List<StadiumPlayerDetailClubDto>>
    {
    }
    public class ClubGetAllQueryHandle : IRequestHandler<ClubGetAllQuery, List<StadiumPlayerDetailClubDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _connectionString;
        public ClubGetAllQueryHandle(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("Default");
        }
        public async Task<List<StadiumPlayerDetailClubDto>> Handle(ClubGetAllQuery query, CancellationToken cancellationToken)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var clubs = await connection.QueryAsync("SELECT * FROM dbo.GetAllDetailClubs()", commandType: CommandType.Text);
                var listClubDto = _mapper.Map<List<StadiumPlayerDetailClubDto>>(clubs);
                return listClubDto;
            }
        }
    }
}
//var clubList = _unitOfWork.Club;
//if (clubList != null)
//{
//    var clubDetail = await clubList
//       .GetQuery()
//       .Include(x => x.Stadium)
//       .Include(x => x.Players)
//       .Where(x => x.Stadium != null && x.Players != null)
//       .ToListAsync();
//    var listClubDto = _mapper.Map<List<StadiumPlayerDetailClubDto>>(clubDetail);
//    return await Task.FromResult(listClubDto);
//}
//return null;