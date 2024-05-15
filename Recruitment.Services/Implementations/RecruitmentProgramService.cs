using Recruitment.Models;
using Recruitment.Models.DTOs;
using Recruitment.Services.Interfaces;

namespace Recruitment.Services.Implementations
{
    public class RecruitmentProgramService : IRecruitmentProgramService
    {

        public IEnumerable<RecruitmentProgram> GetAll()
        {
            throw new NotImplementedException();
        }

        public RecruitmentProgram GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Add(RecruitmentProgram recruitmentProgram)
        {
            throw new NotImplementedException();
        }    
       
        public ResponseMessage Update(Guid id, RecruitmentProgram recruitmentProgram)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage SubmitApplication(ApplicationDTO applicationDTO)
        {
            throw new NotImplementedException();
        }
    }
}
