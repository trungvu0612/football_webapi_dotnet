using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationFootBall.Controllers;
using WebApplicationFootBall.v2.Application.Commands.PlayerCommands;
using WebApplicationFootBall.v2.Application.Queries.PlayerQueries;

namespace WebApplicationFootBall.v2.Controllers
{
    public class PlayerControllerV2 : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PlayerControllerV2(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("v2-get-player-by-id/{PlayerId}")]
        public async Task<IActionResult> GetPlayerById([FromRoute] PlayerGetByIdQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }
        [HttpGet("v2-get-all-player")]
        public async Task<IActionResult> GetAllPlayer()
        {
            var query = new PlayerGetAllQuery();
            var res = await _mediator.Send(query);
            return Ok(res);
        }
        [HttpPost("v2-create-new-player")]
        public async Task<IActionResult> CreatePlayer([FromBody] PlayerPostCommand command)
        {
            try
            {
                var res = await _mediator.Send(command);
                if (res != null)
                {
                    return Ok(res);
                }
                return BadRequest("Not have this stadiumid");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("v2-update-player/{PlayerId}")]
        public async Task<IActionResult> UpdateCountry([FromBody] PlayerPutCommand command, [FromRoute] int PlayerId)
        {
            command.PlayerId = PlayerId;
            var res = await _mediator.Send(command);
            return Ok(res);
        }
        [HttpDelete("v2-delete-player/{PlayerId}")]
        public async Task<IActionResult> DeletePlayer([FromRoute] int PlayerId)
        {
            var command = new PlayerDeleteCommand { PlayerId = PlayerId };
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}
