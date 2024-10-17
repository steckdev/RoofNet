using Microsoft.EntityFrameworkCore;
using RoofTool.Domain.Entities;
using RoofTool.Infrastructure.Interfaces;

namespace RoofTool.Infrastructure.Repositories
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly RoofToolDbContext _context;

        public MeasurementRepository(RoofToolDbContext context)
        {
            _context = context;
        }

        public async Task<Measurement> AddAsync(Measurement measurement)
        {
            _context.Measurements.Add(measurement);
            await _context.SaveChangesAsync();
            return measurement;
        }

        public async Task<Measurement?> GetByPropertyIdAsync(Guid propertyId)
        {
            return await _context.Measurements
                .Include(m => m.Property)
                .FirstOrDefaultAsync(m => m.Property.Id == propertyId);
        }

        public async Task<IEnumerable<Measurement>> GetAllAsync()
        {
            return await _context.Measurements.ToListAsync();
        }
    }
}