
using RoofTool.Domain.Enums;
using System;

namespace RoofTool.Domain.Entities
{
    public class Lead
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Source { get; set; }
        public LeadStatus Status { get; set; }
        public int Score { get; set; }
        public Priority Priority { get; set; }
        public Guid AssignedTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}