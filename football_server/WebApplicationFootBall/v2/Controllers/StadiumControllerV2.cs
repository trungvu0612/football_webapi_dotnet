using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationFootBall.Controllers;
using WebApplicationFootBall.v2.Application.Commands.StadiumCommands;
using WebApplicationFootBall.v2.Application.Queries.StadiumQueries;

namespace WebApplicationFootBall.v2.Controllers
{
    public class StadiumControllerV2 : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public StadiumControllerV2(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("v2-get-stadium-by-id/{StadiumId}")]
        public async Task<IActionResult> GetStadiumById([FromRoute] StadiumGetByIdQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }
        [HttpPost("v2-create-new-stadium")]
        public async Task<IActionResult> CreateNewStadium([FromBody] StadiumPostCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }
        [HttpPut("v2-update-stadium/{StadiumId}")]
        public async Task<IActionResult> UpdateStadium([FromBody] StadiumPutCommand command, [FromRoute] int StadiumId)
        {
            command.StadiumId = StadiumId;
            var res = await _mediator.Send(command);
            return Ok(res);
        }
        [HttpDelete("v2-delete-stadium/{StadiumId}")]
        public async Task<IActionResult> DeleteStadium([FromRoute] int StadiumId)
        {
            var command = new StadiumDeleteCommand { StadiumId = StadiumId };
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}
