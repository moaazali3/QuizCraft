using Microsoft.AspNetCore.Mvc;
using QuizPlatform.Application.DTOs;
using QuizPlatform.Application.Interfaces;

namespace QuizPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnalyticsController : ControllerBase
{
    private readonly IAnalyticsService _analyticsService;

    public AnalyticsController(IAnalyticsService analyticsService)
    {
        _analyticsService = analyticsService;
    }

    [HttpGet("exam/{examId:int}")]
    public async Task<ActionResult<ExamTrackerDto>> GetAnalytics(int examId)
    {
        var analytics = await _analyticsService.GetAnalyticsAsync(examId);
        if (analytics == null) return NotFound(new { message = "الامتحان غير موجود." });

        return Ok(analytics);
    }
}
