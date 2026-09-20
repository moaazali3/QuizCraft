namespace QuizPlatform.Application.DTOs;

public class SubmitExamDto
{
    public int ExamId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string StudentIdentifier { get; set; } = string.Empty;
    public bool AutoSubmittedDueToTimeout { get; set; }
    public List<StudentAnswerInputDto> Answers { get; set; } = new();
}

public class StudentAnswerInputDto
{
    public int QuestionId { get; set; }
    public int? SelectedOptionId { get; set; }
    public string? StudentTextAnswer { get; set; }
}

public class SubmissionResultDto
{
    public int SubmissionId { get; set; }
    public int ExamId { get; set; }
    public string ExamTitle { get; set; } = string.Empty;
    public string StudentName { get; set; } = string.Empty;
    public decimal Score { get; set; }
    public decimal TotalMarks { get; set; }
    public decimal Percentage { get; set; }
    public bool IsPassed { get; set; }
    public DateTime SubmittedAt { get; set; }
    public bool AutoSubmittedDueToTimeout { get; set; }
    public List<StudentAnswerFeedbackDto> Feedback { get; set; } = new();
}

public class StudentAnswerFeedbackDto
{
    public int QuestionId { get; set; }
    public int QuestionNumber { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public int? SelectedOptionId { get; set; }
    public string? SelectedOptionLabel { get; set; }
    public string? SelectedOptionText { get; set; }
    public int? CorrectOptionId { get; set; }
    public string? CorrectOptionLabel { get; set; }
    public string? CorrectOptionText { get; set; }
    public bool IsCorrect { get; set; }
    public decimal EarnedPoints { get; set; }
    public decimal MaxPoints { get; set; }
    public string? Explanation { get; set; }
}
