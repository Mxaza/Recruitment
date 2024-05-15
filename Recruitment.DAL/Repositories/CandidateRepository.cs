using Microsoft.EntityFrameworkCore;
using Recruitment.DAL.Interfaces;
using Recruitment.Models;

namespace Recruitment.DAL.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly RecruitmentContext _context;

        public CandidateRepository(RecruitmentContext context) => _context = context;

        public async Task<IEnumerable<Candidate>> GetAll() => _context.Candidates?.ToList();

        public async Task<Candidate> GetById(Guid id)
        {
            return await _context.Candidates?.AsNoTracking().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(Candidate candidate)
        {
            _context.Candidates?.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Candidate candidate)
        {
            _context.Candidates?.Update(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Candidate candidate)
        {
            _context.Candidates?.Remove(candidate);
            await _context.SaveChangesAsync();
        }
    }
}
