using Recruitment.DAL.Interfaces;
using Recruitment.DAL.Repositories;
using Recruitment.Models;
using Recruitment.Models.DTOs;
using Recruitment.Services.Interfaces;

namespace Recruitment.Services.Implementations
{
    public class RecruitmentProgramService : IRecruitmentProgramService
    {
        private readonly IRecruitmentProgramRepository _recruitmentProgramRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IAnswersRepository _answersRepository;

        public RecruitmentProgramService(IRecruitmentProgramRepository recruitmentProgramRepository, 
            ICandidateRepository candidateRepository, IAnswersRepository answersRepository)
        {
            _recruitmentProgramRepository = recruitmentProgramRepository;
            _candidateRepository = candidateRepository;
            _answersRepository = answersRepository;
        }

        public async Task<RecruitmentProgram> GetById(Guid id) => await _recruitmentProgramRepository.GetById(id);

        public async Task<IEnumerable<RecruitmentProgram>> GetAll() => await _recruitmentProgramRepository.GetAll();

        public async Task<ResponseMessage> Add(RecruitmentProgram employmentProgram)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                await _recruitmentProgramRepository.Add(employmentProgram);
                responseMessage = new ResponseMessage() { Result = true, ResponseCode = ResponseCodes.Ok };
            }
            catch (Exception ex)
            {
                responseMessage = new ResponseMessage() { Result = false, ResponseCode = ResponseCodes.InternalServerError, Message = ex.Message };
            }

            return responseMessage;
        }

        public async Task<ResponseMessage> Update(Guid id, RecruitmentProgram recruitmentProgram)
        {
            ResponseMessage responseMessage = new ResponseMessage();

            try
            {
                RecruitmentProgram existingRecruitmentProgram = await _recruitmentProgramRepository.GetById(id);
                if (existingRecruitmentProgram != null)
                {
                    _recruitmentProgramRepository.Update(existingRecruitmentProgram);
                    responseMessage = new ResponseMessage() { Result = true, ResponseCode = ResponseCodes.NotFound };
                }
                else
                {
                    responseMessage = new ResponseMessage() { Result = false, ResponseCode = ResponseCodes.NotFound };
                }
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
                RecruitmentProgram existingRecruitmentProgram = await _recruitmentProgramRepository.GetById(id);
                if (existingRecruitmentProgram == null)
                    return new ResponseMessage() { Result = false, ResponseCode = ResponseCodes.NotFound };

                _recruitmentProgramRepository.Delete(existingRecruitmentProgram);
            }
            catch (Exception ex)
            {
                responseMessage = new ResponseMessage() { Result = false, ResponseCode = ResponseCodes.InternalServerError, Message = ex.Message };
            }

            return responseMessage;
        }

        public async Task<ResponseMessage> SubmitApplication(ApplicationDTO applicationDTO)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {        
                //Save Candidate Information
                await _candidateRepository.Add(applicationDTO.Candidate);

                // Save Answers
                List<Answer> answersList = new List<Answer>();
                foreach (var item in applicationDTO.Candidate.Answers)
                {
                    var answer = new Answer
                    {
                        QuestionId = item.QuestionId,
                        AnswerValue = item.AnswerValue
                    };
                    answersList.Add(answer);
                }
                await _answersRepository.AddRange(answersList);

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
