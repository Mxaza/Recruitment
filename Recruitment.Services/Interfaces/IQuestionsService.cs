using Recruitment.Models;

namespace Recruitment.Services.Interfaces
{
    public interface IQuestionsService
    {
        ResponseMessage Add(Question question);
        ResponseMessage Delete(Guid id);
        IEnumerable<Question> GetAll();
        Question GetById(Guid id);
        ResponseMessage Update(Guid id, Question question);
    }
}
