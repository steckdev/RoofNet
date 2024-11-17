
using RoofTool.Application.Interfaces;
using RoofTool.Domain.Entities;
using RoofTool.Infrastructure.Interfaces;

namespace RoofTool.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<Report> CreateReportAsync(Guid userId)
        {
            var report = new Report { UserId = userId };
            return await _reportRepository.AddAsync(report);
        }

        public async Task<Report?> GetReportByIdAsync(Guid reportId)
        {
            return await _reportRepository.GetByIdAsync(reportId);
        }

        public async Task UpdateReportStatusAsync(Guid reportId, string status, string? url = null)
        {
            var report = await _reportRepository.GetByIdAsync(reportId);
            if (report != null)
            {
                report.Status = status;
                report.Url = url;
                report.CompletedAt = status == "Completed" ? DateTime.UtcNow : null;
                await _reportRepository.UpdateAsync(report);
            }
        }
    }
}