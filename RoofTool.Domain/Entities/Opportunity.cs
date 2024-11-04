using RoofTool.Domain.Enums;

namespace RoofTool.Domain.Entities
{
    public class Opportunity
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public Property? Property { get; set; }
        public OpportunityStatus Status { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}