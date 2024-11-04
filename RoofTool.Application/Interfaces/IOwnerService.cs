using RoofTool.Domain.Entities;
using RoofTool.Domain.Enums;

namespace RoofTool.Application.Interfaces
{
    public interface IOwnerService
    {
        Task<Owner> CreateOwnerAsync(Owner owner);
        Task<Owner> GetOwnerByIdAsync(Guid id);
        Task UpdateLeadStatusAsync(Guid ownerId, LeadStatus status);
    }
}