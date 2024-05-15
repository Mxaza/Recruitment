using Recruitment.Models;
using Recruitment.Models.DTOs;

namespace Recruitment.Services.Interfaces
{
    public interface IRecruitmentProgramService
    {
        IEnumerable<RecruitmentProgram> GetAll();
        RecruitmentProgram GetById(Guid id);
        ResponseMessage Add(RecruitmentProgram recruitmentProgram);    
        ResponseMessage Update(Guid id, RecruitmentProgram recruitmentProgram);
        ResponseMessage Delete(Guid id);
        ResponseMessage SubmitApplication(ApplicationDTO applicationDTO);
    }
}
