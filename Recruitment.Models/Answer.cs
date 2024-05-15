namespace Recruitment.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string AnswerValue { get; set; }
    }
}
