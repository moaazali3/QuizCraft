using Microsoft.AspNetCore.Mvc;
using QuizPlatform.Application.DTOs;
using QuizPlatform.Application.Interfaces;

namespace QuizPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExamsController : ControllerBase
{
    private readonly IExamService _examService;
    private readonly IPdfParserService _pdfParserService;

    public ExamsController(IExamService examService, IPdfParserService pdfParserService)
    {
        _examService = examService;
        _pdfParserService = pdfParserService;
    }

    [HttpPost("upload-pdf")]
    public async Task<ActionResult<PdfParseResultDto>> UploadPdf(IFormFile? file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest(new { message = "يرجى اختيار ملف PDF صالح." });
        }

        if (!file.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
        {
            return BadRequest(new { message = "الملف المرفوع يجب أن يكون بصيغة PDF." });
        }

        using var stream = file.OpenReadStream();
        var result = await _pdfParserService.ParsePdfAsync(stream, file.FileName);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ExamListDto>> CreateExam([FromBody] CreateExamDto dto)
    {
        if (dto.Questions == null || dto.Questions.Count == 0)
        {
            return BadRequest(new { message = "يجب أن يحتوي الامتحان على سؤال واحد على الأقل." });
        }

        var result = await _examService.CreateExamAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ExamListDto>>> GetAll()
    {
        var exams = await _examService.GetAllExamsAsync();
        return Ok(exams);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ExamDetailDto>> GetById(int id)
    {
        var exam = await _examService.GetExamByIdAsync(id);
        if (exam == null) return NotFound(new { message = "الامتحان غير موجود." });

        return Ok(exam);
    }

    [HttpGet("take/{accessCode}")]
    public async Task<ActionResult<TakeExamDto>> GetForTaking(string accessCode)
    {
        var exam = await _examService.GetExamForTakingAsync(accessCode);
        if (exam == null) return NotFound(new { message = "كود الامتحان غير صالح أو الامتحان غير متاح." });

        return Ok(exam);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _examService.DeleteExamAsync(id);
        if (!success) return NotFound(new { message = "الامتحان غير موجود." });

        return NoContent();
    }

    [HttpPost("{id:int}/regenerate-code")]
    public async Task<ActionResult<object>> RegenerateCode(int id)
    {
        try
        {
            var newCode = await _examService.RegenerateAccessCodeAsync(id);
            return Ok(new { accessCode = newCode });
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new { message = "الامتحان غير موجود." });
        }
    }
}
