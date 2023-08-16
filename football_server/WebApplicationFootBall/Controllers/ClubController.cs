using FootBallWeb.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApplicationFootBall.Business.Dtos.CreateDtos;
using WebApplicationFootBall.Business.Dtos.UpdateDtos;
using WebApplicationFootBall.Business.IService;

namespace WebApplicationFootBall.Controllers
{
    public class ClubController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClubService _clubservice;

        public ClubController(IUnitOfWork unitOfWork, IClubService clubService)
        {
            _unitOfWork = unitOfWork;
            _clubservice = clubService;
        }

        [HttpPost("create-new-club-dto")]
        public IActionResult CreateNewClub([FromBody] ClubPostRequestDto clubCreateDto)
        {
            try
            {
                return Ok(_clubservice.CreateNewClubDto(clubCreateDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-all-club-dto")]
        public IActionResult GetAllClubDto()
        {
            try
            {
                return Ok(_clubservice.GetAllClubDtos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-club-by-id-dto/{id}")]
        public IActionResult GetClubByIdDto([FromRoute] int id)
        {
            try
            {
                return Ok(_clubservice.GetClubByIdDto(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-club-dto/{id}")]
        public IActionResult UpdateClubDto([FromBody] ClubPutRequestDto clubUpdateDto, [FromRoute] int id)
        {
            try
            {
                return Ok(_clubservice.UpdateClubDto(id, clubUpdateDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-club/{id}")]
        public IActionResult DeleteClub([FromRoute] int id)
        {
            try
            {
                var result = _unitOfWork.Club.DeleteClub(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
