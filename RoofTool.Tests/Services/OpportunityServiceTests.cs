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
            var opportunity = new Opportunity();
            _repositoryMock.Setup(r => r.AddAsync(opportunity)).ReturnsAsync(opportunity);

            var result = await _service.CreateOpportunityAsync(opportunity);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.CreatedAt.Date, Is.EqualTo(DateTime.UtcNow.Date));
        }

        [Test]
        public async Task GetOpportunityByIdAsync_ShouldReturnOpportunity()
        {
            var id = Guid.NewGuid();
            var opportunity = new Opportunity();

            _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(opportunity);

            var result = await _service.GetOpportunityByIdAsync(id);

            Assert.That(result, Is.EqualTo(opportunity));
        }

        [Test]
        public async Task UpdateOpportunityStatusAsync_WithExistingOpportunity_ShouldUpdateStatus()
        {
            var id = Guid.NewGuid();
            var status = OpportunityStatus.InProgress;
            var opportunity = new Opportunity();

            _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(opportunity);

            await _service.UpdateOpportunityStatusAsync(id, status);

            Assert.That(opportunity.Status, Is.EqualTo(status));
            _repositoryMock.Verify(r => r.UpdateAsync(opportunity), Times.Once);
        }

        [Test]
        public async Task UpdateOpportunityStatusAsync_WithNonExistingOpportunity_ShouldNotUpdateStatus()
        {
            var id = Guid.NewGuid();
            var status = OpportunityStatus.InProgress;

            _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((Opportunity)null);

            await _service.UpdateOpportunityStatusAsync(id, status);

            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Opportunity>()), Times.Never);
        }
    }
}
