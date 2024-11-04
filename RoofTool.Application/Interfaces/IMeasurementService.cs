using RoofTool.Domain.Entities;

namespace RoofTool.Application.Interfaces
{
    public interface IMeasurementService
    {
        Task<Measurement> AddMeasurementAsync(Measurement measurement);
        Task<Measurement?> GetMeasurementByPropertyIdAsync(Guid propertyId);
    }
}
