
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
    public class LeadServiceTests
    {
        private Mock<ILeadRepository> _repositoryMock;
        private LeadService _service;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<ILeadRepository>();
            _service = new LeadService(_repositoryMock.Object);
        }

        [Test]
        public async Task CreateLeadAsync_ShouldSetCreatedAtAndReturnLead()
        {
            var lead = new Lead()
            {
                Name = "Test Name",
                Email = "test@example.com",
                Phone = "123-456-7890",
                Source = "Test Source"
            };
            _repositoryMock.Setup(r => r.AddAsync(lead)).ReturnsAsync(lead);

            var result = await _service.CreateLeadAsync(lead);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.CreatedAt.Date, Is.EqualTo(DateTime.UtcNow.Date));
        }

        [Test]
        public async Task GetLeadByIdAsync_ShouldReturnLead()
        {
            var id = Guid.NewGuid();
            var lead = new Lead()
            {
                Name = "Test Name",
                Email = "test@example.com",
                Phone = "123-456-7890",
                Source = "Test Source"
            };

            _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(lead);

            var result = await _service.GetLeadByIdAsync(id);

            Assert.That(result, Is.EqualTo(lead));
        }

        [Test]
        public async Task UpdateLeadAsync_ShouldUpdateLead()
        {
            var lead = new Lead()
            {
                Name = "Test Name",
                Email = "test@example.com",
                Phone = "123-456-7890",
                Source = "Test Source"
            };
            _repositoryMock.Setup(r => r.UpdateAsync(lead)).Returns(Task.CompletedTask);

            await _service.UpdateLeadAsync(lead);

            _repositoryMock.Verify(r => r.UpdateAsync(lead), Times.Once);
        }

        [Test]
        public async Task DeleteLeadAsync_ShouldDeleteLead()
        {
            var id = Guid.NewGuid();
            _repositoryMock.Setup(r => r.DeleteAsync(id)).Returns(Task.CompletedTask);

            await _service.DeleteLeadAsync(id);

            _repositoryMock.Verify(r => r.DeleteAsync(id), Times.Once);
        }
    }
}