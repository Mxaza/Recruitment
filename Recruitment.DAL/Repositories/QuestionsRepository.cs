using Microsoft.EntityFrameworkCore;
using Recruitment.DAL.Interfaces;
using Recruitment.Models;

namespace Recruitment.DAL.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly RecruitmentContext _context;

        public QuestionsRepository(RecruitmentContext context) => _context = context;

        public async Task<Question> GetById(Guid id)
        {
            return await _context.Questions?.AsNoTracking().Where(e => e.Id == id)?.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Question>> GetAll()
        {
            return await _context.Questions?.ToListAsync();
        }

        public async Task Add(Question question)
        {
            _context.Questions?.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(List<Question> questions)
        {
            _context.Questions?.AddRangeAsync(questions);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Question question)
        {
            _context.Questions?.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Question question)
        {
            _context.Questions?.Remove(question);
            await _context.SaveChangesAsync();
        }
    }
}
