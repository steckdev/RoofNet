using RoofTool.Domain.Entities;
using RoofTool.Domain.Enums;

namespace RoofTool.Application.Interfaces
{
    public interface IOpportunityService
    {
        Task<Opportunity> CreateOpportunityAsync(Opportunity opportunity);
        Task<Opportunity?> GetOpportunityByIdAsync(Guid id);
        Task UpdateOpportunityStatusAsync(Guid id, OpportunityStatus status);
    }
}