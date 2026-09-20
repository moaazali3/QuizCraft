using QuizPlatform.Core.Entities;
using QuizPlatform.Core.Interfaces;
using QuizPlatform.Infrastructure.Data;

namespace QuizPlatform.Infrastructure.Repositories;

public class SubmissionRepository : Repository<Submission>, ISubmissionRepository
{
    public SubmissionRepository(AppDbContext context) : base(context)
    {
    }

    public Task<Submission?> GetWithAnswersAsync(int id)
    {
        // TODO: [Team Task - DAL 4] جلب تسليم الطالب مع تفاصيل إجاباته وخياراتها والامتحان
        // تلميح: استخدام Include للـ Answers والـ SelectedOption والـ Exam

        throw new NotImplementedException("يرجى كتابة استعلام جلب التسليم هنا.");
    }

    public Task<IReadOnlyList<Submission>> GetByExamIdAsync(int examId)
    {
        // TODO: [Team Task - DAL 5] جلب جميع التسليمات الخاصة بامتحان معين
        // تلميح: استخدام Where(s => s.ExamId == examId) مع Include للـ Answers

        throw new NotImplementedException("يرجى كتابة استعلام جلب تسليمات الامتحان هنا.");
    }
}
