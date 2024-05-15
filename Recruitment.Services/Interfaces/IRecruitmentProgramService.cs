using Recruitment.Models;
using Recruitment.Models.DTOs;

namespace Recruitment.Services.Interfaces
{
    public interface IRecruitmentProgramService
    {
        Task<IEnumerable<RecruitmentProgram>> GetAll();
        Task<RecruitmentProgram> GetById(Guid id);
        Task<ResponseMessage> Add(RecruitmentProgram recruitmentProgram);
        Task<ResponseMessage> Update(Guid id, RecruitmentProgram recruitmentProgram);
        Task<ResponseMessage> Delete(Guid id);
        Task<ResponseMessage> SubmitApplication(ApplicationDTO applicationDTO);
    }
}
