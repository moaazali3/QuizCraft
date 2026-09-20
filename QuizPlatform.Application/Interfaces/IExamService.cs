using QuizPlatform.Application.DTOs;

namespace QuizPlatform.Application.Interfaces;

public interface IExamService
{
    Task<ExamListDto> CreateExamAsync(CreateExamDto dto);
    Task<IReadOnlyList<ExamListDto>> GetAllExamsAsync();
    Task<ExamDetailDto?> GetExamByIdAsync(int id);
    Task<TakeExamDto?> GetExamForTakingAsync(string accessCode);
    Task<bool> DeleteExamAsync(int id);
    Task<string> RegenerateAccessCodeAsync(int id);
}
