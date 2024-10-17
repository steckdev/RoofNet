using Moq;
using RoofTool.Application.Services;
using RoofTool.Domain.Entities;
using RoofTool.Domain.ValueObjects;
using RoofTool.Infrastructure.Interfaces;

namespace RoofTool.Tests.Services
{
    [TestClass]
    public class MeasurementServiceTests
    {
        private Mock<IMeasurementRepository> _repositoryMock;
        private MeasurementService _service;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<IMeasurementRepository>();
            _service = new MeasurementService(_repositoryMock.Object);
        }

        [TestMethod]
        public async Task AddMeasurementAsync_ShouldReturnMeasurement()
        {
            var measurement = new Measurement()
            {
                Id = Guid.NewGuid(),
                Property = new Property()
                {
                    Address = "123 Main St",
                    Owner = new Owner()
                    {
                        FullName = "John Doe" 
                    },
                },
                Edges = new List<PolygonEdge>()
            };
            _repositoryMock.Setup(r => r.AddAsync(measurement)).ReturnsAsync(measurement);

            var result = await _service.AddMeasurementAsync(measurement);

            Assert.IsNotNull(result);
            Assert.AreEqual(measurement.Id, result.Id);
        }
    }
}