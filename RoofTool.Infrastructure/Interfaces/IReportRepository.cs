
using RoofTool.Domain.Entities;

namespace RoofTool.Infrastructure.Interfaces
{
    public interface IReportRepository
    {
        Task<Report> AddAsync(Report report);
        Task<Report?> GetByIdAsync(Guid reportId);
        Task UpdateAsync(Report report);
    }
}