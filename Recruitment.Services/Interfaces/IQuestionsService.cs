using Recruitment.Models;

namespace Recruitment.Services.Interfaces
{
    public interface IQuestionsService
    {
        Task<ResponseMessage> Add(Question question);        
        Task<IEnumerable<Question>> GetAll();
        Task<Question> GetById(Guid id);
        Task<ResponseMessage> Update(Guid id, Question question);
        Task<ResponseMessage> Delete(Guid id);
    }
}
