using Microsoft.AspNetCore.Mvc;
using Recruitment.Models.DTOs;
using Recruitment.Models;
using Recruitment.Services.Interfaces;

namespace Recruitment.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecruitmentProgramsController : ControllerBase
    {
        private readonly ILogger<RecruitmentProgramsController> _logger;
        private readonly IRecruitmentProgramService _service;

        public RecruitmentProgramsController(ILogger<RecruitmentProgramsController> logger, IRecruitmentProgramService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _service.GetAll();
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(ResponseCodes.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetById(id);
                if (result == null)
                    return NotFound();

                return Ok(result);               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(ResponseCodes.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RecruitmentProgram recruitmentProgram)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {   
                ResponseMessage responseMessage = await _service.Add(recruitmentProgram);
                return StatusCode(responseMessage.ResponseCode, responseMessage.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(ResponseCodes.InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RecruitmentProgram recruitmentProgram)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                ResponseMessage responseMessage = await _service.Update(id, recruitmentProgram);
                return StatusCode(responseMessage.ResponseCode, responseMessage.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(ResponseCodes.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                ResponseMessage responseMessage = await _service.Delete(id);
                return StatusCode(responseMessage.ResponseCode, responseMessage.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(ResponseCodes.InternalServerError, ex.Message);
            }

        }

        [HttpPost("Submit")]
        public async Task<IActionResult> SubmitApplication([FromBody] ApplicationDTO applicationDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                ResponseMessage response = await _service.SubmitApplication(applicationDTO);

                return StatusCode(response.ResponseCode, response.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(ResponseCodes.InternalServerError, ex.Message);
            }
        }
    }
}
