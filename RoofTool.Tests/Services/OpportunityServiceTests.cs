using Moq;
using NUnit.Framework;
using RoofTool.Application.Services;
using RoofTool.Domain.Entities;
using RoofTool.Domain.Enums;
using RoofTool.Infrastructure.Repositories;

namespace RoofTool.Tests.Services
{
    [TestFixture]
    public class OpportunityServiceTests
    {
        private Mock<IOpportunityRepository> _repositoryMock;
        private OpportunityService _service;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IOpportunityRepository>();
            _service = new OpportunityService(_repositoryMock.Object);
        }

        [Test]
        public async Task CreateOpportunityAsync_ShouldSetCreatedAtAndReturnOpportunity()
        {
            // Arrange
            var opportunity = new Opportunity();
            _repositoryMock.Setup(r => r.AddAsync(opportunity)).ReturnsAsync(opportunity);

            // Act
            var result = await _service.CreateOpportunityAsync(opportunity);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.CreatedAt.Date, Is.EqualTo(DateTime.UtcNow.Date));
        }

        [Test]
        public async Task GetOpportunityByIdAsync_ShouldReturnOpportunity()
        {
            // Arrange
            var id = Guid.NewGuid();
            var opportunity = new Opportunity();

            _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(opportunity);

            // Act
            var result = await _service.GetOpportunityByIdAsync(id);

            // Assert
            Assert.That(result, Is.EqualTo(opportunity));
        }

        [Test]
        public async Task UpdateOpportunityStatusAsync_WithExistingOpportunity_ShouldUpdateStatus()
        {
            // Arrange
            var id = Guid.NewGuid();
            var status = OpportunityStatus.InProgress;
            var opportunity = new Opportunity();

            _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(opportunity);

            // Act
            await _service.UpdateOpportunityStatusAsync(id, status);

            // Assert
            Assert.That(opportunity.Status, Is.EqualTo(status));
            _repositoryMock.Verify(r => r.UpdateAsync(opportunity), Times.Once);
        }

        [Test]
        public async Task UpdateOpportunityStatusAsync_WithNonExistingOpportunity_ShouldNotUpdateStatus()
        {
            // Arrange
            var id = Guid.NewGuid();
            var status = OpportunityStatus.InProgress;

            _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((Opportunity)null);

            // Act
            await _service.UpdateOpportunityStatusAsync(id, status);

            // Assert
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Opportunity>()), Times.Never);
        }
    }
}
