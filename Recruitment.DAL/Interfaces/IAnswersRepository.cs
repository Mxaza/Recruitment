using Recruitment.Models;

namespace Recruitment.DAL.Interfaces
{
    public interface IAnswersRepository
    {
        Task<IEnumerable<Answer>> GetAll();
        Task<Answer> GetById(Guid id);
        Task Add(Answer answer);           
        void Update(Answer answer);
        void Delete(Answer answer);
    }
}
