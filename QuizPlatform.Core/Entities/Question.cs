using QuizPlatform.Core.Enums;

namespace QuizPlatform.Core.Entities;

public class Question : BaseEntity
{
    public int ExamId { get; set; }
    public Exam? Exam { get; set; }

    public int QuestionNumber { get; set; }
    public string Text { get; set; } = string.Empty;
    public QuestionType Type { get; set; } = QuestionType.MultipleChoice;
    public decimal Points { get; set; } = 1.0m;
    public string? Explanation { get; set; }

    public ICollection<Option> Options { get; set; } = new List<Option>();
}
