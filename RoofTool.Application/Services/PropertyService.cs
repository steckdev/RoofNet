using RoofTool.Application.Interfaces;
using RoofTool.Domain.Entities;
using RoofTool.Infrastructure.Interfaces;

namespace RoofTool.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repository;

        public PropertyService(IPropertyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Property> CreatePropertyAsync(Property property)
        {
            return await _repository.AddAsync(property);
        }

        public async Task<Property?> GetPropertyByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}