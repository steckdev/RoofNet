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

            var result = await _service.CreatePropertyAsync(property);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(property.Id));
        }

        [Test]
        public async Task GetPropertyByIdAsync_ShouldReturnProperty()
        {
            var id = Guid.NewGuid();
            var property = new Property
            {
                Id = id,
                Address = "123 Main St",
                Owner = new Owner
                {
                    FullName = "John Doe",
                    Properties = new List<Property>()
                }
            };

            _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(property);

            var result = await _service.GetPropertyByIdAsync(id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(id));
        }
    }
}
