using QuizPlatform.Application.DTOs;
using QuizPlatform.Application.Interfaces;

namespace QuizPlatform.Infrastructure.Services;

public class PdfParserService : IPdfParserService
{
    public Task<PdfParseResultDto> ParsePdfAsync(Stream pdfStream, string fileName)
    {
        // TODO: [Team Task 1] استخراج الأسئلة من ملف الـ PDF بدون AI
        // 1. استخدام مكتبة UglyToad.PdfPig لقراءة نصوص جميع الصفحات
        // 2. معالجة النصوص وتنظيف المسافات والأرقام (العربية والإنجليزية)
        // 3. استخدام Regular Expressions (Regex) للتعرف على:
        //    - بداية السؤال (مثال: 1. أو Q1: أو س1:)
        //    - الخيارات المتاحة (A, B, C, D أو أ، ب، ج، د)
        //    - مفتاح الإجابات إن وجد (Answer Key / الإجابات النموذجية)
        // 4. إرجاع النتيجة في كائن PdfParseResultDto

        throw new NotImplementedException("يرجى كتابة كود استخراج الأسئلة بالـ Regex ومكتبة PdfPig هنا.");
    }
}
