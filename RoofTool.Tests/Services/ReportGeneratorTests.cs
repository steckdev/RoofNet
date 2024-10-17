using NUnit.Framework;
using RoofTool.Application.Services;
using RoofTool.Domain.Entities;
using RoofTool.Domain.ValueObjects;
using System.Net;

namespace RoofTool.Tests.Services
{
    public class ReportGeneratorTests
    {
        [Test]
        public void GenerateCsvReport_ShouldReturnCsvString()
        {
            // Arrange
            var measurements = new List<Measurement>
                {
                    new Measurement
                    {
                        Id = Guid.NewGuid(),
                        PropertyId = Guid.NewGuid(),
                        Property = new Property
                        {
                            Address = "123 Main St",
                            Owner = new Owner
                            {
                                FullName = "John Doe"
                            }
                        },
                        Edges = new List<PolygonEdge>()
                    },
                    new Measurement
                    {
                        Id = Guid.NewGuid(),
                        PropertyId = Guid.NewGuid(),
                        Property = new Property
                        {
                            Address = "123 Main St",
                            Owner = new Owner
                            {
                                FullName = "John Doe"
                            }
                        },
                        Edges = new List<PolygonEdge>()
                    }
                };

            var reportGenerator = new ReportGenerator();

            // Act
            var csvReport = reportGenerator.GenerateCsvReport(measurements);

            // Assert
            Assert.That(csvReport, Is.Not.Null);
            Assert.That(csvReport, Contains.Substring("PropertyId,Area,Slope"));
            Assert.That(csvReport, Contains.Substring(measurements[0].PropertyId.ToString()));
            Assert.That(csvReport, Contains.Substring(measurements[0].Area.ToString()));
            Assert.That(csvReport, Contains.Substring(measurements[0].Slope.ToString()));
            Assert.That(csvReport, Contains.Substring(measurements[1].PropertyId.ToString()));
            Assert.That(csvReport, Contains.Substring(measurements[1].Area.ToString()));
            Assert.That(csvReport, Contains.Substring(measurements[1].Slope.ToString()));
        }
    }
}
