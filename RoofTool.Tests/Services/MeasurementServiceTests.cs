using Moq;
using NUnit.Framework;
using RoofTool.Application.Services;
using RoofTool.Domain.Entities;
using RoofTool.Domain.ValueObjects;
using RoofTool.Infrastructure.Interfaces;

namespace RoofTool.Tests.Services
{
    [TestFixture]
    public class MeasurementServiceTests
    {
        private Mock<IMeasurementRepository> _repositoryMock;
        private MeasurementService _service;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IMeasurementRepository>();
            _service = new MeasurementService(_repositoryMock.Object);
        }

        [Test]
        public async Task AddMeasurementAsync_ShouldReturnMeasurement()
        {
            // Arrange
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

            // Act
            var result = await _service.AddMeasurementAsync(measurement);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(measurement.Id));
        }

        [Test]
        public async Task GetMeasurementByPropertyIdAsync_ShouldReturnMeasurement()
        {
            // Arrange
            var propertyId = Guid.NewGuid();
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
            _repositoryMock.Setup(r => r.GetByPropertyIdAsync(propertyId)).ReturnsAsync(measurement);

            // Act
            var result = await _service.GetMeasurementByPropertyIdAsync(propertyId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(measurement.Id));
        }
    }
}