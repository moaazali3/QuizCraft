using QuizPlatform.Core.Entities;
using QuizPlatform.Core.Interfaces;
using QuizPlatform.Infrastructure.Data;

namespace QuizPlatform.Infrastructure.Repositories;

public class ExamRepository : Repository<Exam>, IExamRepository
{
    public ExamRepository(AppDbContext context) : base(context)
    {
    }

    public Task<Exam?> GetWithQuestionsAndOptionsAsync(int id)
    {
        // TODO: [Team Task - DAL 1] جلب الامتحان مع الأسئلة والخيارات
        // تلميح: استخدام _context.Exams.Include(e => e.Questions).ThenInclude(q => q.Options)

        throw new NotImplementedException("يرجى كتابة استعلام جلب الامتحان وتفاصيله هنا.");
    }

    public Task<Exam?> GetByAccessCodeAsync(string accessCode)
    {
        // TODO: [Team Task - DAL 2] جلب الامتحان باستخدام كود الدخول AccessCode
        // تلميح: استخدام Include للأسئلة والخيارات والبحث بـ FirstOrDefaultAsync

        throw new NotImplementedException("يرجى كتابة استعلام جلب الامتحان بالكود هنا.");
    }

    public Task<IReadOnlyList<Exam>> GetAllWithDetailsAsync()
    {
        // TODO: [Team Task - DAL 3] جلب قائمة الامتحانات مع عدد الأسئلة والتسليمات
        // تلميح: استخدام Include للـ Questions والـ Submissions

        throw new NotImplementedException("يرجى كتابة استعلام جلب قائمة الامتحانات هنا.");
    }
}
