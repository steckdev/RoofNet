using RoofTool.Domain.Entities;

namespace RoofTool.Infrastructure.Interfaces
{
    public interface IPropertyRepository
    {
        Task<Property> AddAsync(Property property);
        Task<Property?> GetByIdAsync(Guid id);
    }
}