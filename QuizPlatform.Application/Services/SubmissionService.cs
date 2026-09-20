using QuizPlatform.Application.DTOs;
using QuizPlatform.Application.Interfaces;
using QuizPlatform.Core.Interfaces;

namespace QuizPlatform.Application.Services;

public class SubmissionService : ISubmissionService
{
    private readonly ISubmissionRepository _submissionRepository;
    private readonly IExamRepository _examRepository;

    public SubmissionService(
        ISubmissionRepository submissionRepository,
        IExamRepository examRepository)
    {
        _submissionRepository = submissionRepository;
        _examRepository = examRepository;
    }

    public Task<SubmissionResultDto> SubmitExamAsync(SubmitExamDto dto)
    {
        // TODO: [Team Task 3.1] استقبال إجابات الطالب والتصحيح التلقائي
        // 1. جلب الامتحان بأسئلته وإجاباته النموذجية للتأكد من وجوده
        // 2. مقارنة كل اختيار للطالب بالاختيار الصحيح (IsCorrect == true)
        // 3. احتساب الدرجة الكلية المكتسبة (EarnedPoints) بناءً على وزن كل سؤال
        // 4. مقارنة النسبة المئوية بنسبة النجاح المحددة في الامتحان لتحديد (IsPassed)
        // 5. تسجيل حالة المؤقت: هل سلم قبل انتهاء الوقت أم حدث تسليم إجباري (AutoSubmittedDueToTimeout)
        // 6. حفظ الـ Submission والـ StudentAnswers في قاعدة البيانات
        // 7. إرجاع النتيجة الكاملة مع تقرير الفيدباك (SubmissionResultDto)

        throw new NotImplementedException("يرجى كتابة منطق استقبال وتصحيح الامتحان هنا.");
    }

    public Task<SubmissionResultDto?> GetSubmissionResultAsync(int submissionId)
    {
        // TODO: [Team Task 3.2] جلب نتيجة تسليم طالب محدد مع تفاصيل الإجابات الصحيحة والدرجات
        // 1. جلب بيانات التسليم والأسئلة المرتبطة به
        // 2. إرجاع SubmissionResultDto مع تحليل الإجابات

        throw new NotImplementedException("يرجى كتابة منطق جلب نتيجة التسليم هنا.");
    }

    public Task<ExamTrackerDto?> GetExamTrackerAsync(int examId)
    {
        // TODO: [Team Task 3.3] تتبع الطلاب ومعدلات النجاح للمدرس (Tracker)
        // 1. جلب كل تسليمات الطلاب الخاصة بهذا الامتحان
        // 2. حساب إجمالي الطلاب الذين حلوا، عدد الناجحين، وعدد الراسبين
        // 3. حساب متوسط الدرجات ونسبة النجاح العامة
        // 4. تحليل مستوى كل سؤال: كم طالب أجاب صح وكم طالب أخطأ، وتحديد أصعب سؤال (Hardest Question)
        // 5. إرجاع البيانات في كائن ExamTrackerDto

        throw new NotImplementedException("يرجى كتابة منطق شاشة تتبع الطلاب هنا.");
    }
}
