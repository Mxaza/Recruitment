using Recruitment.Models;

namespace Recruitment.DAL.Interfaces
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetAll();
        Task<Candidate> GetById(Guid id);
        Task Add(Candidate candidate);       
        void Update(Candidate candidate);
        void Delete(Candidate candidate);
    }
}