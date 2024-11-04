using Microsoft.EntityFrameworkCore;
using RoofTool.Domain.Entities;

namespace RoofTool.Infrastructure.Repositories
{
    public class OpportunityRepository : IOpportunityRepository
    {
        private readonly RoofToolDbContext _context;

        public OpportunityRepository(RoofToolDbContext context)
        {
            _context = context;
        }

        public async Task<Opportunity> AddAsync(Opportunity opportunity)
        {
            _context.Opportunities.Add(opportunity);
            await _context.SaveChangesAsync();
            return opportunity;
        }

        public async Task<Opportunity?> GetByIdAsync(Guid id)
        {
            return await _context.Opportunities
                .Include(o => o.Property)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(Opportunity opportunity)
        {
            _context.Opportunities.Update(opportunity);
            await _context.SaveChangesAsync();
        }
    }
}
