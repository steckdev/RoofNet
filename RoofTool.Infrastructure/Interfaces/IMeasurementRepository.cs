using RoofTool.Domain.Entities;

namespace RoofTool.Infrastructure.Interfaces
{
    public interface IMeasurementRepository
    {
        Task<Measurement> AddAsync(Measurement measurement);
        Task<Measurement?> GetByPropertyIdAsync(Guid propertyId);
    }
}