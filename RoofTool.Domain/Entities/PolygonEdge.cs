namespace RoofTool.Domain.Entities
{
    public class PolygonEdge
    {
        public Guid Id { get; set; }
        public decimal Length { get; set; }
        public decimal Angle { get; set; }
        public Guid MeasurementId { get; set; }
        public required Measurement Measurement { get; set; }
    }
}