namespace RoofTool.Domain.Enums
{
    public enum LeadStatus
    {
        New,
        Contacted,
        Quoted,
        Closed
    }

    public enum OpportunityStatus
    {
        Open,
        InProgress,
        Won,
        Lost
    }
}

namespace RoofTool.Domain.ValueObjects
{
    public class RoofDetails
    {
        public string Type { get; set; }
        public decimal Pitch { get; set; }
    }

    public class ContactInfo
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class PolygonEdge
    {
        public decimal Length { get; set; }
        public decimal Angle { get; set; }
    }
}