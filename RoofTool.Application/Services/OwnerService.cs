using RoofTool.Application.Interfaces;
using RoofTool.Domain.Entities;
using RoofTool.Domain.Enums;
using RoofTool.Infrastructure.Repositories;

namespace RoofTool.Application.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _repository;

        public OwnerService(IOwnerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Owner> CreateOwnerAsync(Owner owner)
        {
            return await _repository.AddAsync(owner);
        }

        public async Task<Owner> GetOwnerByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateLeadStatusAsync(Guid ownerId, LeadStatus status)
        {
            var owner = await _repository.GetByIdAsync(ownerId);
            if (owner != null)
            {
                owner.LeadStatus = status;
                await _repository.UpdateAsync(owner);
            }
        }
    }
}