
using Microsoft.EntityFrameworkCore;
using RoofTool.Domain.Entities;
using RoofTool.Infrastructure.Interfaces;

namespace RoofTool.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly RoofToolDbContext _context;

        public ReportRepository(RoofToolDbContext context)
        {
            _context = context;
        }

        public async Task<Report> AddAsync(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<Report?> GetByIdAsync(Guid reportId)
        {
            return await _context.Reports.FindAsync(reportId);
        }

        public async Task UpdateAsync(Report report)
        {
            _context.Reports.Update(report);
            await _context.SaveChangesAsync();
        }
    }
}