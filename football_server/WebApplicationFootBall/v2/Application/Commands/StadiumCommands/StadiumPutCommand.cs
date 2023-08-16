using AutoMapper;
using FootBallWeb.Domain.Interfaces;
using MediatR;
using WebApplicationFootBall.Business.Dtos.UpdateDtos;

namespace WebApplicationFootBall.v2.Application.Commands.StadiumCommands
{
    public class StadiumPutCommand : StadiumPutRequestDto, IRequest<StadiumPutRequestDto>
    {
        public int StadiumId { get; set; }
    }
    public class StadiumPutCommandHandler : IRequestHandler<StadiumPutCommand, StadiumPutRequestDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public StadiumPutCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<StadiumPutRequestDto> Handle(StadiumPutCommand command, CancellationToken cancellationToken)
        {
            var checkStadium = _unitOfWork.Stadium.GetById(command.StadiumId);
            if (checkStadium != null)
            {
                _mapper.Map(command, checkStadium);
                _unitOfWork.Save();
                var updatedStadiumDto = _mapper.Map<StadiumPutRequestDto>(checkStadium);
                return await Task.FromResult(updatedStadiumDto);
            }
            return null;
        }
    }
}
