namespace Recruitment.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid RecruitmentProgramId { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public List<string> Options { get; set; }
    }
}
