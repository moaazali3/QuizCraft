using QuizPlatform.Core.Enums;

namespace QuizPlatform.Application.DTOs;

public class ParsedQuestionDto
{
    public int QuestionNumber { get; set; }
    public string Text { get; set; } = string.Empty;
    public QuestionType Type { get; set; } = QuestionType.MultipleChoice;
    public decimal Points { get; set; } = 1.0m;
    public List<ParsedOptionDto> Options { get; set; } = new();
    public string? DetectedCorrectOption { get; set; } // e.g. "B"
}

public class ParsedOptionDto
{
    public string Label { get; set; } = string.Empty; // "A", "B", "C", "D"
    public string Text { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
}

public class PdfParseResultDto
{
    public bool Success { get; set; }
    public string FileName { get; set; } = string.Empty;
    public int TotalQuestionsDetected { get; set; }
    public List<ParsedQuestionDto> Questions { get; set; } = new();
    public List<string> Warnings { get; set; } = new();
}
