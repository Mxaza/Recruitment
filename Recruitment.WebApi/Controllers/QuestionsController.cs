using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment.Models.DTOs;
using Recruitment.Models;
using Recruitment.Services.Interfaces;

namespace Recruitment.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {

        private readonly ILogger<QuestionsController> _logger;
        private readonly IQuestionsService _service;

        public QuestionsController(ILogger<QuestionsController> logger, IQuestionsService service)
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
        public async Task<IActionResult> Add([FromBody] QuestionDTO questionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var question = new Question
                {
                    Text = questionDTO.Text,
                    Type = questionDTO.Type
                };

                ResponseMessage responseMessage = await _service.Add(question);
                return StatusCode(responseMessage.ResponseCode, responseMessage.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(ResponseCodes.InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Question question)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                ResponseMessage responseMessage = await _service.Update(id, question);
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
    }
}
