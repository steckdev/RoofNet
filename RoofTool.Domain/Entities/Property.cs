using RoofTool.Domain.ValueObjects;

namespace RoofTool.Domain.Entities
{
    public class Property
    {
        public Guid Id { get; set; }
        public required string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public RoofDetails? RoofDetails { get; set; }
        public Guid OwnerId { get; set; }
        public required Owner Owner { get; set; }
        public List<PolygonEdge> PolygonEdges { get; set; } = new();
    }
}