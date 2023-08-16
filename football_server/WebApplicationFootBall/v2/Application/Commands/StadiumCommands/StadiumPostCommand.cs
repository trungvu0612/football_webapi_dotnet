using AutoMapper;
using FootBallWeb.Domain.Entities;
using FootBallWeb.Domain.Interfaces;
using MediatR;
using WebApplicationFootBall.Business.Dtos.CreateDtos;

namespace WebApplicationFootBall.v2.Application.Commands.StadiumCommands
{
    public class StadiumPostCommand : StadiumPostRequestDto, IRequest<StadiumPostRequestDto>
    {
    }
    public class StadiumPostCommandHandler : IRequestHandler<StadiumPostCommand, StadiumPostRequestDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public StadiumPostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<StadiumPostRequestDto> Handle(StadiumPostCommand command, CancellationToken cancellationToken)
        {
            var res = _mapper.Map<StadiumPostRequestDto>(command);
            var staidum = _mapper.Map<Stadium>(res);
            await _unitOfWork.Stadium.AddAsync(staidum);
            _unitOfWork.Save();
            return await Task.FromResult(res);
        }
    }
}
