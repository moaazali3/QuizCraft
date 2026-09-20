using QuizPlatform.Core.Enums;

namespace QuizPlatform.Application.DTOs;

public class CreateExamDto
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int DurationMinutes { get; set; } = 30;
    public decimal PassPercentage { get; set; } = 50.0m;
    public string? SourcePdfName { get; set; }
    public List<CreateQuestionDto> Questions { get; set; } = new();
}

public class CreateQuestionDto
{
    public int QuestionNumber { get; set; }
    public string Text { get; set; } = string.Empty;
    public QuestionType Type { get; set; } = QuestionType.MultipleChoice;
    public decimal Points { get; set; } = 1.0m;
    public string? Explanation { get; set; }
    public List<CreateOptionDto> Options { get; set; } = new();
}

public class CreateOptionDto
{
    public string Label { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
}

public class ExamListDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string AccessCode { get; set; } = string.Empty;
    public int QuestionsCount { get; set; }
    public decimal TotalMarks { get; set; }
    public int DurationMinutes { get; set; }
    public ExamStatus Status { get; set; }
    public int SubmissionsCount { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class ExamDetailDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string AccessCode { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
    public decimal TotalMarks { get; set; }
    public decimal PassPercentage { get; set; }
    public ExamStatus Status { get; set; }
    public string? SourcePdfName { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<QuestionDetailDto> Questions { get; set; } = new();
}

public class QuestionDetailDto
{
    public int Id { get; set; }
    public int QuestionNumber { get; set; }
    public string Text { get; set; } = string.Empty;
    public QuestionType Type { get; set; }
    public decimal Points { get; set; }
    public string? Explanation { get; set; }
    public List<OptionDetailDto> Options { get; set; } = new();
}

public class OptionDetailDto
{
    public int Id { get; set; }
    public string Label { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
}

// DTO for student taking exam (does NOT expose IsCorrect)
public class TakeExamDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string AccessCode { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
    public decimal TotalMarks { get; set; }
    public int TotalQuestions { get; set; }
    public List<TakeQuestionDto> Questions { get; set; } = new();
}

public class TakeQuestionDto
{
    public int Id { get; set; }
    public int QuestionNumber { get; set; }
    public string Text { get; set; } = string.Empty;
    public QuestionType Type { get; set; }
    public decimal Points { get; set; }
    public List<TakeOptionDto> Options { get; set; } = new();
}

public class TakeOptionDto
{
    public int Id { get; set; }
    public string Label { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}
