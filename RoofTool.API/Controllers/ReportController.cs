using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoofTool.Application.Interfaces;
using RoofTool.Domain.Entities;

namespace RoofTool.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] Guid userId)
        {
            var report = await _reportService.CreateReportAsync(userId);
            return Ok(report);
        }

        [HttpGet("{reportId}")]
        public async Task<IActionResult> GetReport(Guid reportId)
        {
            var report = await _reportService.GetReportByIdAsync(reportId);
            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }

        [HttpPost("{reportId}/status")]
        public async Task<IActionResult> UpdateReportStatus(Guid reportId, [FromBody] string status, [FromQuery] string? url)
        {
            await _reportService.UpdateReportStatusAsync(reportId, status, url);
            return NoContent();
        }
    }
}