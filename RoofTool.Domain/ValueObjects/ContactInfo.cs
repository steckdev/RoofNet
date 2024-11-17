using Microsoft.EntityFrameworkCore;

namespace RoofTool.Domain.ValueObjects
{
    public class ContactInfo
    {
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}