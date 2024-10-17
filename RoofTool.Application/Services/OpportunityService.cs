using RoofTool.Application.Interfaces;
using RoofTool.Domain.Entities;
using RoofTool.Domain.Enums;
using RoofTool.Infrastructure.Repositories;

namespace RoofTool.Application.Services
{
    public class OpportunityService : IOpportunityService
    {
        private readonly IOpportunityRepository _repository;

        public OpportunityService(IOpportunityRepository repository)
        {
            _repository = repository;
        }

        public async Task<Opportunity> CreateOpportunityAsync(Opportunity opportunity)
        {
            opportunity.CreatedAt = DateTime.UtcNow;
            return await _repository.AddAsync(opportunity);
        }

        public async Task<Opportunity> GetOpportunityByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateOpportunityStatusAsync(Guid id, OpportunityStatus status)
        {
            var opportunity = await _repository.GetByIdAsync(id);
            if (opportunity != null)
            {
                opportunity.Status = status;
                await _repository.UpdateAsync(opportunity);
            }
        }
    }
}