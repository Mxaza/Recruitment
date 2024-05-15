using Recruitment.Models;

namespace Recruitment.DAL.Interfaces
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetAll();
        Task<Candidate> GetById(Guid id);
        Task Add(Candidate candidate);       
        Task Update(Candidate candidate);
        Task Delete(Candidate candidate);
    }
}