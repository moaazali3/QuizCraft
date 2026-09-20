namespace QuizPlatform.Application.DTOs;

public class ExamTrackerDto
{
    public int ExamId { get; set; }
    public string ExamTitle { get; set; } = string.Empty;
    public string AccessCode { get; set; } = string.Empty;
    public int TotalSubmissions { get; set; }
    public int PassedCount { get; set; }
    public int FailedCount { get; set; }
    public decimal PassRatePercentage { get; set; }
    public decimal AverageScore { get; set; }
    public decimal TotalMarks { get; set; }
    public List<StudentSubmissionSummaryDto> Students { get; set; } = new();
    public List<QuestionStatDto> QuestionStats { get; set; } = new();
}

public class StudentSubmissionSummaryDto
{
    public int SubmissionId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string StudentIdentifier { get; set; } = string.Empty;
    public decimal Score { get; set; }
    public decimal TotalMarks { get; set; }
    public decimal Percentage { get; set; }
    public bool IsPassed { get; set; }
    public DateTime SubmittedAt { get; set; }
    public bool AutoSubmittedDueToTimeout { get; set; }
}

public class QuestionStatDto
{
    public int QuestionId { get; set; }
    public int QuestionNumber { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public int TotalAttempts { get; set; }
    public int CorrectAttempts { get; set; }
    public int WrongAttempts { get; set; }
    public decimal SuccessRatePercentage { get; set; }
    public bool IsHardest { get; set; }
}
