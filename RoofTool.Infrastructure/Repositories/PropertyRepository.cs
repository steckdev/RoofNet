using Microsoft.EntityFrameworkCore;
using RoofTool.Domain.Entities;
using RoofTool.Infrastructure.Interfaces;

namespace RoofTool.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RoofToolDbContext _context;

        public PropertyRepository(RoofToolDbContext context)
        {
            _context = context;
        }

        public async Task<Property> AddAsync(Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return property;
        }

        public async Task<Property?> GetByIdAsync(Guid id)
        {
            return await _context.Properties.FindAsync(id);
        }
    }
}