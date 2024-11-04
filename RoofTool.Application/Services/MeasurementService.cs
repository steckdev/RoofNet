using RoofTool.Application.Interfaces;
using RoofTool.Domain.Entities;
using RoofTool.Infrastructure.Interfaces;

namespace RoofTool.Application.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementRepository _repository;

        public MeasurementService(IMeasurementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Measurement> AddMeasurementAsync(Measurement measurement)
        {
            return await _repository.AddAsync(measurement);
        }

        public async Task<Measurement?> GetMeasurementByPropertyIdAsync(Guid propertyId)
        {
            return await _repository.GetByPropertyIdAsync(propertyId);
        }
    }
}