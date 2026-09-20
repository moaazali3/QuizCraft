using Microsoft.AspNetCore.Mvc;
using QuizPlatform.Application.DTOs;
using QuizPlatform.Application.Interfaces;

namespace QuizPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubmissionsController : ControllerBase
{
    private readonly ISubmissionService _submissionService;

    public SubmissionsController(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }

    [HttpPost]
    public async Task<ActionResult<SubmissionResultDto>> Submit([FromBody] SubmitExamDto dto)
    {
        try
        {
            var result = await _submissionService.SubmitExamAsync(dto);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SubmissionResultDto>> GetResult(int id)
    {
        var result = await _submissionService.GetSubmissionResultAsync(id);
        if (result == null) return NotFound(new { message = "النتيجة غير موجودة." });

        return Ok(result);
    }

    [HttpGet("exam/{examId:int}/tracker")]
    public async Task<ActionResult<ExamTrackerDto>> GetTracker(int examId)
    {
        var tracker = await _submissionService.GetExamTrackerAsync(examId);
        if (tracker == null) return NotFound(new { message = "الامتحان غير موجود." });

        return Ok(tracker);
    }
}
