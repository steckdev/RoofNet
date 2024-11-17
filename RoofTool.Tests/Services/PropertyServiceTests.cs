using Moq;
using NUnit.Framework;
using RoofTool.Application.Services;
using RoofTool.Domain.Entities;
using RoofTool.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace RoofTool.Tests.Services
{
    [TestFixture]
    public class PropertyServiceTests
    {
        private Mock<IPropertyRepository> _repositoryMock;
        private PropertyService _service;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IPropertyRepository>();
            _service = new PropertyService(_repositoryMock.Object);
        }

        [Test]
        public async Task CreatePropertyAsync_ShouldReturnCreatedProperty()
        {
            // Arrange
            var property = new Property()
            {
                Id = Guid.NewGuid(),
                Address = "123 Main St",
                Owner = new Owner()
                {
                    FullName = "John Doe",
                    Properties = new List<Property>() { }
                }
            };
            _repositoryMock.Setup(r => r.AddAsync(property)).ReturnsAsync(property);

            // Act
            var result = await _service.CreatePropertyAsync(property);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(property.Id));
        }

        [Test]
        public async Task GetPropertyByIdAsync_ShouldReturnProperty()
        {
            // Arrange
            var propertyId = Guid.NewGuid();
            var property = new Property()
            {
                Id = propertyId,
                Address = "123 Main St",
                Owner = new Owner()
                {
                    FullName = "John Doe",
                    Properties = new List<Property>() { }
                }
            };
            _repositoryMock.Setup(r => r.GetByIdAsync(propertyId)).ReturnsAsync(property);

            // Act
            var result = await _service.GetPropertyByIdAsync(propertyId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Id, Is.EqualTo(property.Id));
        }
    }
}
