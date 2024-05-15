using Microsoft.EntityFrameworkCore;
using Recruitment.DAL.Interfaces;
using Recruitment.Models;

namespace Recruitment.DAL.Repositories
{
    public class AnswersRepository : IAnswersRepository
    {
        private readonly RecruitmentContext _context;

        public AnswersRepository(RecruitmentContext context) => _context = context;

        public async Task<Answer> GetById(Guid id)
        {
            return await _context.Answers?.AsNoTracking().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Answer>> GetAll()
        {
            return await _context.Answers?.ToListAsync();
        }

        public async Task Add(Answer answer)
        {
            _context.Answers?.AddAsync(answer);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(List<Answer> answers)
        {
            _context.Answers?.AddRangeAsync(answers);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Answer answer)
        {
            _context.Answers?.Update(answer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Answer answer)
        {
            _context.Answers?.Remove(answer);
            await _context.SaveChangesAsync();
        }
    }
}
