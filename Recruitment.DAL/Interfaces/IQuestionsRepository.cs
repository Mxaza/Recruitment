using Recruitment.Models;
using System.Security.Cryptography;

namespace Recruitment.DAL.Interfaces
{
    public interface IQuestionsRepository
    {
        Task<IEnumerable<Question>> GetAll();
        Task<Question> GetById(Guid id);
        Task Add(Question question);
        Task Update(Question question);
        Task Delete(Question question);
    }
}
