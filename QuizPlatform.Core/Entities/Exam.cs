using QuizPlatform.Core.Enums;

namespace QuizPlatform.Core.Entities;

public class Exam : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string AccessCode { get; set; } = string.Empty;
    public int DurationMinutes { get; set; } = 30; // 0 for unlimited
    public decimal TotalMarks { get; set; }
    public decimal PassPercentage { get; set; } = 50.0m;
    public ExamStatus Status { get; set; } = ExamStatus.Draft;
    public string? SourcePdfName { get; set; }

    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
