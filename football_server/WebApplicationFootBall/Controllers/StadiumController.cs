using FootBallWeb.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApplicationFootBall.Business.Dtos.CreateDtos;
using WebApplicationFootBall.Business.Dtos.UpdateDtos;
using WebApplicationFootBall.Business.IService;

namespace WebApplicationFootBall.Controllers
{
    public class StadiumController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStadiumService _stadiumService;

        public StadiumController(IUnitOfWork unitOfWork, IStadiumService stadiumService)
        {
            _unitOfWork = unitOfWork;
            _stadiumService = stadiumService;
        }
        [HttpPost("create-new-stadium-dto")]
        public IActionResult CreateNewStadiumDto([FromBody] StadiumPostRequestDto stadiumCreateDto)
        {
            try
            {
                return Ok(_stadiumService.CreateNewStadiumDto(stadiumCreateDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-all-stadium-dto")]
        public IActionResult GetAllStadiumDto()
        {
            try
            {
                return Ok(_stadiumService.GetAllStadiumDtos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-stadium-by-id/{id}")]
        public IActionResult GetStadiumById([FromRoute] int id)
        {
            try
            {
                return Ok(_stadiumService.GetStadiumByIdDto(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-stadium-dto/{id}")]
        public IActionResult UpdateStadiumDto([FromBody] StadiumPutRequestDto stadiumUpdateDto, [FromRoute] int id)
        {
            try
            {
                return Ok(_stadiumService.UpdateStadiumDto(id, stadiumUpdateDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-stadium/{id}")]
        public IActionResult DeleteStadium([FromRoute] int id)
        {
            try
            {
                var result = _unitOfWork.Stadium.DeleteStadium(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
