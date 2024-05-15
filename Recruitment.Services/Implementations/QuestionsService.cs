using Recruitment.Models;
using Recruitment.Services.Interfaces;

namespace Recruitment.Services.Implementations
{
    public class QuestionsService : IQuestionsService
    {

        public IEnumerable<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public Question GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Add(Question question)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Update(Guid id, Question question)
        {
            throw new NotImplementedException();
        }
    }
}
