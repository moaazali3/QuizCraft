namespace QuizPlatform.Core.Entities;

public class StudentAnswer : BaseEntity
{
    public int SubmissionId { get; set; }
    public Submission? Submission { get; set; }

    public int QuestionId { get; set; }
    public Question? Question { get; set; }

    public int? SelectedOptionId { get; set; }
    public Option? SelectedOption { get; set; }

    public string? StudentTextAnswer { get; set; }
    public bool IsCorrect { get; set; }
    public decimal EarnedPoints { get; set; }
}
