
using RoofTool.Domain.Entities;

namespace RoofTool.Application.Interfaces
{
    public interface IReportService
    {
        Task<Report> CreateReportAsync(Guid userId);
        Task<Report?> GetReportByIdAsync(Guid reportId);
        Task UpdateReportStatusAsync(Guid reportId, string status, string? url = null);
    }
}