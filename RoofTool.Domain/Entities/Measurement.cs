using RoofTool.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoofTool.Domain.Entities
{
    public class Measurement
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public required Property Property { get; set; }
        public required List<PolygonEdge> Edges { get; set; }
        public decimal Area => CalculateArea();
        public decimal Slope => CalculateSlope();

        private decimal CalculateArea()
        {
            return 11.11M;
            // Implementation of area calculation
        }

        private decimal CalculateSlope()
        {
            return 22.22M;
            // Implementation of slope calculation
        }
    }
}