using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationFootBall.Controllers;
using WebApplicationFootBall.v2.Application.Commands.CountryCommands;
using WebApplicationFootBall.v2.Application.Queries.CountryQueries;

namespace WebApplicationFootBall.v2.Controllers
{
    public class CountryControllerV2 : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CountryControllerV2(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("v2-get-country-by-id/{CountryId}")]
        public async Task<IActionResult> GetCountryById([FromRoute] CountryGetByIdQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }
        [HttpGet("v2-get-all-country")]
        public async Task<IActionResult> GetAllCountry()
        {
            var query = new CountryGetAllQuery();
            var res = await _mediator.Send(query);
            return Ok(res);
        }
        [HttpPost("v2-create-new-country")]
        public async Task<IActionResult> CreateNewCountry([FromBody] CountryPostCommand command)
        {
            try
            {
                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("v2-update-country/{CountryId}")]
        public async Task<IActionResult> UpdateCountry([FromBody] CountryPutCommand command, [FromRoute] int CountryId)
        {
            command.CountryId = CountryId;
            var res = await _mediator.Send(command);
            return Ok(res);
        }
        [HttpDelete("v2-delete-country/{CountryId}")]
        public async Task<IActionResult> DeleteCountry([FromRoute] int CountryId)
        {
            var command = new CountryDeleteCommand { CountryId = CountryId };
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}
