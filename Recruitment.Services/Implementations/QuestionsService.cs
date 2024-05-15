using Recruitment.DAL.Interfaces;
using Recruitment.Models;
using Recruitment.Services.Interfaces;

namespace Recruitment.Services.Implementations
{
    public class QuestionsService : IQuestionsService
    {

        private readonly IQuestionsRepository _questionsRepository;

        public QuestionsService(IQuestionsRepository questionsRepository) => _questionsRepository = questionsRepository;

        public async Task<Question> GetById(Guid id) => await _questionsRepository.GetById(id);

        public async Task<IEnumerable<Question>> GetAll() =>  await _questionsRepository.GetAll();

        public async Task<ResponseMessage> Add(Question question)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                await _questionsRepository.Add(question);
                responseMessage = new ResponseMessage() { Result = true, ResponseCode = ResponseCodes.Ok };
            }
            catch (Exception ex)
            {
                responseMessage = new ResponseMessage() { Result = false, ResponseCode = ResponseCodes.InternalServerError, Message = ex.Message };
            }
            return responseMessage;
        }

        public async Task<ResponseMessage> Update(Guid id, Question question)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                Question existingQuestion = await _questionsRepository.GetById(id);
                if (existingQuestion == null)
                    return new ResponseMessage() { Result = false, ResponseCode = ResponseCodes.NotFound };

                _questionsRepository.Update(question);
                responseMessage = new ResponseMessage() { Result = true, ResponseCode = ResponseCodes.Ok };
            }
            catch (Exception ex)
            {
                responseMessage = new ResponseMessage() { Result = false, ResponseCode = ResponseCodes.InternalServerError, Message = ex.Message };
            }
            return responseMessage;
        }

        public async Task<ResponseMessage> Delete(Guid id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                Question existingQuestion = await _questionsRepository.GetById(id);
                if (existingQuestion == null)
                    return new ResponseMessage() { Result = false, ResponseCode = ResponseCodes.NotFound };

                _questionsRepository.Delete(existingQuestion);
                responseMessage = new ResponseMessage() { Result = true, ResponseCode = ResponseCodes.Ok };
            }
            catch (Exception ex)
            {
                responseMessage = new ResponseMessage() { Result = false, ResponseCode = ResponseCodes.InternalServerError, Message = ex.Message };
            }
            return responseMessage;
        }
    }
}
