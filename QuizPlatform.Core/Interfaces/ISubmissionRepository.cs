using QuizPlatform.Core.Entities;

namespace QuizPlatform.Core.Interfaces;

public interface ISubmissionRepository : IRepository<Submission>
{
    Task<Submission?> GetWithAnswersAsync(int id);
    Task<IReadOnlyList<Submission>> GetByExamIdAsync(int examId);
}
