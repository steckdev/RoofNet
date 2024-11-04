using RoofTool.Domain.Entities;

namespace RoofTool.Infrastructure.Repositories
{
    public interface IOwnerRepository
    {
        Task<Owner> AddAsync(Owner owner);
        Task<Owner> GetByIdAsync(Guid id);
        Task UpdateAsync(Owner owner);
    }
}