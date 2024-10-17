using RoofTool.Domain.Entities;

namespace RoofTool.Application.Interfaces
{
    public interface IPropertyService
    {
        Task<Property> CreatePropertyAsync(Property property);
        Task<Property?> GetPropertyByIdAsync(Guid id);
    }
}