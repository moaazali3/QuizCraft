# 🎯 QuizCraft

منصة تفاعلية لتحويل ملفات PDF التي تحتوي على أسئلة (اختيار من متعدد) إلى امتحانات تفاعلية أونلاين، بدون استخدام AI - بالاعتماد على خوارزمية Regex/Parsing.

---

## 🏛️ المعمارية (4-Layer Clean Architecture)

المشروع مبني باستخدام **.NET 10** ومعمارية الـ 4 طبقات:

- **`QuizPlatform.Core`**: الكيانات (`Entities`)، الـ Enums، والـ `Interfaces` الأساسية.
- **`QuizPlatform.Application`**: منطق التطبيق (`Services`)، الـ DTOs، والـ Interfaces للخدمات.
- **`QuizPlatform.Infrastructure`**: طبقة البيانات (`EF Core / SQLite`)، المستودعات (`Repositories`)، وخدمة استخراج الـ PDF (`PdfPig`).
- **`QuizPlatform.API`**: واجهات البرمجة (`ASP.NET Core Web API Controllers`)، الإعدادات، ونقاط النهاية.

---

## 📋 مهام الفريق (Assignments)
تم تفريغ منطق الدوال ووضع علامات `TODO` وتعليمات مفصلة. للاطلاع على توزيع المهام بالتفصيل، يرجى مراجعة ملف:
👉 **[ASSIGNMENTS.md](ASSIGNMENTS.md)**

---

## 🚀 تشغيل المشروع محلياً

```bash
# بناء المشروع
dotnet build QuizCraft.slnx

# تشغيل الـ API
dotnet run --project QuizPlatform.API
```
