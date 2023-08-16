using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationFootBall.Controllers;
using WebApplicationFootBall.v2.Application.Commands.ClubCommands;
using WebApplicationFootBall.v2.Application.Queries.ClubQueries;

namespace WebApplicationFootBall.v2.Controllers
{
    public class ClubControllerV2 : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ClubControllerV2(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("v2-get-club-by-id/{ClubId}")]
        public async Task<IActionResult> GetClubById([FromRoute] ClubGetByIdQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }
        [HttpGet("v2-get-all-club")]
        public async Task<IActionResult> GetAllClub()
        {
            var query = new ClubGetAllQuery();
            var res = await _mediator.Send(query);
            return Ok(res);
        }
        [HttpPost("v2-create-new-club")]
        public async Task<IActionResult> CreateClub([FromBody] ClubPostCommand command)
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
        [HttpPut("v2-update-club/{ClubId}")]
        public async Task<IActionResult> UpdateClub([FromBody] ClubPutCommand command, [FromRoute] int ClubId)
        {
            command.ClubId = ClubId;
            var res = await _mediator.Send(command);
            return Ok(res);
        }
        [HttpDelete("v2-delete-club/{ClubId}")]
        public async Task<IActionResult> DeleteClub([FromRoute] int ClubId)
        {
            var command = new ClubDeleteCommand { ClubId = ClubId };
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}
