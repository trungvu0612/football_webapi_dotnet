using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApplicationFootBall.Business.Dtos.CreateDtos;

namespace WebApplicationFootBall.v2.Application.Commands.CountryCommands
{
    public class CountryPostCommand : CountryPostRequestDto, IRequest<CountryPostRequestDto>
    {

    }
    public class CountryPostCommandHandler : IRequestHandler<CountryPostCommand, CountryPostRequestDto>
    {
        //private readonly IMapper _mapper;
        //private readonly IUnitOfWork _unitOfWork;
        private readonly string _connectionString;
        public CountryPostCommandHandler(IConfiguration configuration)
        {
            //_unitOfWork = unitOfWork;
            //_mapper = mapper;
            _connectionString = configuration.GetConnectionString("Default");
        }

        public async Task<CountryPostRequestDto> Handle(CountryPostCommand command, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync(
                    "dbo.CreateNewCountry",
                    new
                    {
                        @Name = command.Name,
                        @TwoLetterIsoCode = command.TwoLetterIsoCode,
                        @ThreeLetterIsoCode = command.ThreeLetterIsoCode,
                        @FlagUrl = command.FlagUrl,
                        @DisplayOrder = command.DisplayOrder,
                        @CreatedBy = command.CreatedBy,
                        @CreatedDate = command.CreatedDate,
                    },
                    commandType: CommandType.StoredProcedure);
                return command;
            }
            //var res = _mapper.Map<CountryPostRequestDto>(command);
            //var country = _mapper.Map<Country>(res);
            //await _unitOfWork.Country.AddAsync(country);
            //_unitOfWork.Save();
            //return await Task.FromResult(res);
        }
    }
}
