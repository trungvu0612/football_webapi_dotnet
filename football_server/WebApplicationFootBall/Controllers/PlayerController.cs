using FootBallWeb.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApplicationFootBall.Business.Dtos.CreateDtos;
using WebApplicationFootBall.Business.Dtos.UpdateDtos;
using WebApplicationFootBall.Business.IService;

namespace WebApplicationFootBall.Controllers
{
    public class PlayerController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlayerService _playerService;

        public PlayerController(IUnitOfWork unitOfWork, IPlayerService playerService)
        {
            _unitOfWork = unitOfWork;
            _playerService = playerService;
        }
        [HttpPost("create-new-player-dto")]
        public IActionResult CreateNewPlayer([FromBody] PlayerPostRequestDto playerCreateDto)
        {
            try
            {
                return Ok(_playerService.CreateNewPlayerDto(playerCreateDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-all-player-dto")]
        public IActionResult GetAllPlayerDto()
        {
            try
            {
                return Ok(_playerService.GetAllPlayerDtos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-player-by-id-dto/{id}")]
        public IActionResult GetPlayerByIdDto([FromRoute] int id)
        {
            try
            {
                return Ok(_playerService.GetPlayerByIdDto(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-player-dto/{id}")]
        public IActionResult UpdatePlayerDto([FromBody] PlayerPutRequestDto playerUpdateDto, [FromRoute] int id)
        {
            try
            {
                return Ok(_playerService.UpdatePlayerDto(id, playerUpdateDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-player/{id}")]
        public IActionResult DeletePlayer([FromRoute] int id)
        {
            try
            {
                var result = _unitOfWork.Player.DeletePlayer(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
