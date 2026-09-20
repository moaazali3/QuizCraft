using QuizPlatform.Core.Entities;

namespace QuizPlatform.Core.Interfaces;

public interface IExamRepository : IRepository<Exam>
{
    Task<Exam?> GetWithQuestionsAndOptionsAsync(int id);
    Task<Exam?> GetByAccessCodeAsync(string accessCode);
    Task<IReadOnlyList<Exam>> GetAllWithDetailsAsync();
}
