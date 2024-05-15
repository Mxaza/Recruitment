using Recruitment.Models;

namespace Recruitment.DAL.Interfaces
{
    public interface IRecruitmentProgramRepository
    {
        Task<IEnumerable<RecruitmentProgram>> GetAll();
        Task<RecruitmentProgram> GetById(Guid id);
        Task Add(RecruitmentProgram recruitmentProgram);        
        void Update(RecruitmentProgram recruitmentProgram);
        void Delete(RecruitmentProgram recruitmentProgram);
    }
}
