namespace Recruitment.Models.DTOs
{
    public class ApplicationDTO
    {
        public Guid EmploymentProgramId { get; set; }
        public Candidate Candidate { get; set; }
        public List<AnswerDTO> Answers { get; set; }
    }
}
