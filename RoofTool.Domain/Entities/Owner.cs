using RoofTool.Domain.Enums;
using RoofTool.Domain.ValueObjects;

namespace RoofTool.Domain.Entities
{
    public class Owner
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public ContactInfo? ContactInfo { get; set; }
        public LeadStatus LeadStatus { get; set; }
        public required ICollection<Property> Properties { get; set; }
    }
}