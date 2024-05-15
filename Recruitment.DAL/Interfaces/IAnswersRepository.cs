using Recruitment.Models;

namespace Recruitment.DAL.Interfaces
{
    public interface IAnswersRepository
    {
        Task<IEnumerable<Answer>> GetAll();
        Task<Answer> GetById(Guid id);
        Task Add(Answer answer);           
        Task AddRange(List<Answer> answer);           
        Task Update(Answer answer);
        Task Delete(Answer answer);
    }
}
