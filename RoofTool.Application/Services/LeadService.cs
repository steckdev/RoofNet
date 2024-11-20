
using RoofTool.Application.Interfaces;
using RoofTool.Domain.Entities;
using RoofTool.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace RoofTool.Application.Services
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _repository;

        public LeadService(ILeadRepository repository)
        {
            _repository = repository;
        }

        public async Task<Lead> CreateLeadAsync(Lead lead)
        {
            lead.CreatedAt = DateTime.UtcNow;
            lead.UpdatedAt = DateTime.UtcNow;
            return await _repository.AddAsync(lead);
        }

        public async Task<Lead> GetLeadByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateLeadAsync(Lead lead)
        {
            lead.UpdatedAt = DateTime.UtcNow;
            await _repository.UpdateAsync(lead);
        }

        public async Task DeleteLeadAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}