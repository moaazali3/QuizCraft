using QuizPlatform.Application.DTOs;

namespace QuizPlatform.Application.Interfaces;

public interface IAnalyticsService
{
    Task<ExamTrackerDto?> GetAnalyticsAsync(int examId);
}
