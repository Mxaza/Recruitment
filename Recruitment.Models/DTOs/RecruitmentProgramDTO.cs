namespace Recruitment.Models.DTOs
{
    public class RecruitmentProgramDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<QuestionDTO> Questions { get; set; }
    }
}
