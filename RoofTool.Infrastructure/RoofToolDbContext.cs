using Microsoft.EntityFrameworkCore;
using RoofTool.Domain.Entities;

namespace RoofTool.Infrastructure
{
    public class RoofToolDbContext : DbContext
    {
        public RoofToolDbContext(DbContextOptions<RoofToolDbContext> options) : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
    }
}