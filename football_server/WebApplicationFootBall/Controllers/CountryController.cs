using FootBallWeb.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.IService;
using WebApplicationFootBall.Business.Dtos.CreateDtos;
using WebApplicationFootBall.Business.Dtos.UpdateDto;

namespace WebApplicationFootBall.Controllers
{
    public class CountryController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICountryService _countryService;

        public CountryController(IUnitOfWork unitOfWork, ICountryService countryService)
        {
            _unitOfWork = unitOfWork;
            _countryService = countryService;
        }

        [HttpPost("create-new-country-dto")]
        public IActionResult CreateNewCountryDto([FromBody] CountryPostRequestDto countryCreateDto)
        {
            try
            {
                return Ok(_countryService.CreateNewCountryDto(countryCreateDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-all-country-dto")]
        public IActionResult GetAllCountryDto()
        {
            try
            {
                return Ok(_countryService.GetAllCountryDtos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-country-by-id/{id}")]
        public IActionResult GetCountryById([FromRoute] int id)
        {
            try
            {
                return Ok(_countryService.GetCountryByIdDto(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-country-dto/{id}")]
        public IActionResult UpdateCountryDto([FromBody] CountryPutRequestDto countryUpdateDto, [FromRoute] int id)
        {
            try
            {
                return Ok(_countryService.UpdateCountryDto(id, countryUpdateDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-country/{id}")]
        public IActionResult DeleteCountry([FromRoute] int id)
        {
            try
            {
                var result = _unitOfWork.Country.DeleteCountry(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
