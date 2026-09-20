namespace QuizPlatform.Core.Entities;

public class Option : BaseEntity
{
    public int QuestionId { get; set; }
    public Question? Question { get; set; }

    public string Label { get; set; } = string.Empty; // "A", "B", "C", "D"
    public string Text { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
}
