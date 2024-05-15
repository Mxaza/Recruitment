using Microsoft.EntityFrameworkCore;
using Recruitment.DAL.Interfaces;
using Recruitment.Models;

namespace Recruitment.DAL.Repositories
{
    internal class RecruitmentProgramRepository : IRecruitmentProgramRepository
    {
        private readonly RecruitmentContext _context;

        public RecruitmentProgramRepository(RecruitmentContext context) => _context = context;

        public async Task<RecruitmentProgram> GetById(Guid id)
        {
            return await _context.RecruitmentPrograms?.AsNoTracking().Where(e => e.Id == id)?.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RecruitmentProgram>> GetAll()
        {
            return await _context.RecruitmentPrograms?.ToListAsync();
        }

        public async Task Add(RecruitmentProgram recruitmentProgram)
        {
            _context.RecruitmentPrograms?.Add(recruitmentProgram);
            await _context.SaveChangesAsync();
        }

        public async Task Update(RecruitmentProgram recruitmentProgram)
        {
            _context.RecruitmentPrograms?.Update(recruitmentProgram);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(RecruitmentProgram recruitmentProgram)
        {
            _context.RecruitmentPrograms?.Remove(recruitmentProgram);
            await _context.SaveChangesAsync();
        }
    }
}
