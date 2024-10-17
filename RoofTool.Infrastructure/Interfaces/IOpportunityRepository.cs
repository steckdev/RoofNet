using RoofTool.Domain.Entities;

namespace RoofTool.Infrastructure.Repositories
{
    public interface IOpportunityRepository
    {
        Task<Opportunity> AddAsync(Opportunity opportunity);
        Task<Opportunity?> GetByIdAsync(Guid id);
        Task UpdateAsync(Opportunity opportunity);
    }
}
