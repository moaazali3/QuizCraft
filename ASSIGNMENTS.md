# 📋 دليل مهام الفريق (Project Tasks & Assignment Guide)

مشروع: **منصة تحويل ملفات الـ PDF إلى امتحانات تفاعلية (QuizCraft)**  
المعمارية: **4-Layer Architecture (.NET 10 / C#)**  

تم تجهيز الهيكل بالكامل (الكيانات، الـ Interfaces، الـ DTOs، والـ Controllers).  
الآن، تم تفريغ الأكواد الداخلية وتحويلها إلى دوال معلقة (`NotImplementedException`) مصحوبة بتعليمات `TODO` واضحة لكل عضو في الفريق.

---

## 🏗️ نظرة عامة على تقسيم الطبقات

```
QuizCraft/
├── QuizPlatform.Core/            # 1. الكيانات والـ Interfaces الأساسية
├── QuizPlatform.Infrastructure/  # 2. مستودعات البيانات ومكتبة استخراج الـ PDF
├── QuizPlatform.Application/     # 3. منطق التطبيق والـ Services والتصحيح
└── QuizPlatform.API/             # 4. الـ Controllers ونقاط الـ Web API
```

---

## 👥 توزيع المهام على أعضاء الفريق

### 🧑‍💻 المهمة الأولى: خوارزمية استخراج الـ PDF بدون AI
- **الملف المطلوب إكماله**: [`PdfParserService.cs`](file:///f:/projects/WEB/QuizCraft/QuizPlatform.Infrastructure/Services/PdfParserService.cs)
- **المكتبة المستخدمة**: `UglyToad.PdfPig`
- **المطلوب تنفيذه**:
  1. فتح وقراءة صفحات الـ PDF واستخراج النصوص.
  2. تنظيف النصوص وتوحيد الأرقام (العربية والإنجليزية).
  3. استخدام Regex لاستخراج أرقام الأسئلة، نصوصها، والخيارات (A, B, C, D أو أ، ب، ج، د).
  4. استخراج مفتاح الإجابات (Answer Key) إن وجد وتحديد الاختيار الصحيح.
  5. إرجاع النتيجة في كائن `PdfParseResultDto`.

---

### 🧑‍💻 المهمة الثانية: استعلامات قاعدة البيانات (Data Access Layer)
- **الملفات المطلوبة**:
  - [`ExamRepository.cs`](file:///f:/projects/WEB/QuizCraft/QuizPlatform.Infrastructure/Repositories/ExamRepository.cs)
  - [`SubmissionRepository.cs`](file:///f:/projects/WEB/QuizCraft/QuizPlatform.Infrastructure/Repositories/SubmissionRepository.cs)
- **المطلوب تنفيذه**:
  1. `GetWithQuestionsAndOptionsAsync(id)`: استعلام EF Core لجلب الامتحان مع أسئلته وخياراته (`Include`).
  2. `GetByAccessCodeAsync(code)`: البحث عن الامتحان باستخدام الكود الفريد المخصص للطلاب.
  3. `GetAllWithDetailsAsync()`: جلب كل الامتحانات مع عدد الأسئلة والتسليمات.
  4. `GetWithAnswersAsync(id)`: جلب تسليم الطالب مع إجاباته والتصحيح.
  5. `GetByExamIdAsync(examId)`: جلب جميع إجابات الطلاب لامتحان معين لصفحة التتبع.

---

### 🧑‍💻 المهمة الثالثة: منطق إدارة ونشر الامتحانات (Exam Service)
- **الملف المطلوب إكماله**: [`ExamService.cs`](file:///f:/projects/WEB/QuizCraft/QuizPlatform.Application/Services/ExamService.cs)
- **المطلوب تنفيذه**:
  1. `CreateExamAsync`:
     - توليد رمز دخول فريد (`AccessCode` مثل `QC-584920`).
     - حساب الدرجة الكلية للامتحان.
     - حفظ الامتحان والأسئلة في قاعدة البيانات.
  2. `GetExamForTakingAsync`:
     - جلب بيانات الامتحان للطالب **مع حجب حقل `IsCorrect`** لحماية الامتحان من الغش البرمجي.
  3. `GetAllExamsAsync` & `GetExamByIdAsync`: جلب الامتحانات وعرض تفاصيلها للمعلم.
  4. `DeleteExamAsync`: حذف الامتحان.

---

### 🧑‍💻 المهمة الرابعة: التصحيح التلقائي وتتبع الطلاب (Submissions & Analytics)
- **الملفات المطلوبة**:
  - [`SubmissionService.cs`](file:///f:/projects/WEB/QuizCraft/QuizPlatform.Application/Services/SubmissionService.cs)
  - [`AnalyticsService.cs`](file:///f:/projects/WEB/QuizCraft/QuizPlatform.Application/Services/AnalyticsService.cs)
- **المطلوب تنفيذه**:
  1. `SubmitExamAsync`:
     - استلام إجابات الطالب ومقارنتها بالإجابات الصحيحة في قاعدة البيانات.
     - احتساب مجموع النقاط المكتسبة والنسبة المئوية.
     - تحديد هل نجح أم رسب استناداً لنسبة النجاح المقررة.
     - مراعاة هل تم التسليم بسبب انتهاء الوقت تلقائياً (`AutoSubmittedDueToTimeout`).
     - إرجاع تقرير الفيدباك والنتيجة الفورية.
  2. `GetExamTrackerAsync`:
     - حساب عدد الطلاب الذين حلوا، عدد الناجحين، وعدد الراسبين.
     - تحليل نسبة الخطأ لكل سؤال وتحديد أصعب سؤال في الامتحان (`Hardest Question`).

---

## 🚀 كيفية تشغيل المشروع للتحقق:
```bash
cd f:\projects\WEB\QuizCraft
dotnet build QuizCraft.slnx
dotnet run --project QuizPlatform.API
```
ثم فتح المتصفح على: `https://localhost:xxxx/openapi/v1.json` أو فحص الـ Endpoints.
