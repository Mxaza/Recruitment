using Recruitment.Models;
using System.Security.Cryptography;

namespace Recruitment.DAL.Interfaces
{
    public interface IQuestionsRepository
    {
        Task<IEnumerable<Question>> GetAll();
        Task<Question> GetById(Guid id);
        Task Add(Question question);
        Task AddRange(List<Question> questions);
        Task Update(Question question);
        Task Delete(Question question);
    }
}
