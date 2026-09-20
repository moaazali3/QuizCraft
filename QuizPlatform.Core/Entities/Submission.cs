namespace QuizPlatform.Core.Entities;

public class Submission : BaseEntity
{
    public int ExamId { get; set; }
    public Exam? Exam { get; set; }

    public string StudentName { get; set; } = string.Empty;
    public string StudentIdentifier { get; set; } = string.Empty; // e.g. Student ID, Phone, or Email
    public DateTime StartedAt { get; set; } = DateTime.UtcNow;
    public DateTime? SubmittedAt { get; set; }
    public decimal Score { get; set; }
    public decimal TotalMarks { get; set; }
    public bool IsPassed { get; set; }
    public bool AutoSubmittedDueToTimeout { get; set; }

    public ICollection<StudentAnswer> Answers { get; set; } = new List<StudentAnswer>();
}
