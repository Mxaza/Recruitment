using Recruitment.Models;

namespace Recruitment.DAL.Interfaces
{
    public interface IRecruitmentProgramRepository
    {
        Task<IEnumerable<RecruitmentProgram>> GetAll();
        Task<RecruitmentProgram> GetById(Guid id);
        Task Add(RecruitmentProgram recruitmentProgram);        
        Task Update(RecruitmentProgram recruitmentProgram);
        Task Delete(RecruitmentProgram recruitmentProgram);
    }
}
