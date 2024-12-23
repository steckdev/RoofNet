﻿using Moq;
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
            var measurement = new Measurement()
            {
                Id = Guid.NewGuid(),
                Property = new Property()
                {
                    Address = "123 Main St",
                    Owner = new Owner()
                    {
                        FullName = "John Doe",
                        Properties = new List<Property>()
                    },
                },
                Edges = new List<PolygonEdge>()
            };
            _repositoryMock.Setup(r => r.AddAsync(measurement)).ReturnsAsync(measurement);

            var result = await _service.AddMeasurementAsync(measurement);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(measurement.Id));
        }

        [Test]
        public async Task GetMeasurementByPropertyIdAsync_ShouldReturnMeasurement()
        {
            var propertyId = Guid.NewGuid();
            var measurement = new Measurement
            {
                Id = Guid.NewGuid(),
                PropertyId = propertyId,
                Property = new Property
                {
                    Address = "123 Main St",
                    Owner = new Owner
                    {
                        FullName = "John Doe",
                        Properties = new List<Property>()
                    }
                },
                Edges = new List<PolygonEdge>()
            };

            _repositoryMock.Setup(r => r.GetByPropertyIdAsync(propertyId)).ReturnsAsync(measurement);

            var result = await _service.GetMeasurementByPropertyIdAsync(propertyId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.PropertyId, Is.EqualTo(propertyId));
        }
    }
}