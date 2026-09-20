using QuizPlatform.Application.DTOs;

namespace QuizPlatform.Application.Interfaces;

public interface ISubmissionService
{
    Task<SubmissionResultDto> SubmitExamAsync(SubmitExamDto dto);
    Task<SubmissionResultDto?> GetSubmissionResultAsync(int submissionId);
    Task<ExamTrackerDto?> GetExamTrackerAsync(int examId);
}
