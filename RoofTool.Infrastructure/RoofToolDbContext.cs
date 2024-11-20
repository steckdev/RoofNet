using Microsoft.EntityFrameworkCore;
using RoofTool.Domain.Entities;
using RoofTool.Domain.ValueObjects;
using Npgsql.EntityFrameworkCore.PostgreSQL;

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
        public DbSet<Report> Reports { get; set; }
        public DbSet<PolygonEdge> PolygonEdges { get; set; }
        public DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Measurement>()
                .HasMany(m => m.Edges)
                .WithOne(e => e.Measurement)
                .HasForeignKey(e => e.MeasurementId);

            modelBuilder.Entity<PolygonEdge>().HasKey(e => e.Id);

            modelBuilder.Entity<Owner>()
                .OwnsOne(o => o.ContactInfo);

            modelBuilder.Entity<Property>().OwnsOne(o => o.RoofDetails);

            modelBuilder.Entity<Lead>()
                .HasOne<Owner>()
                .WithMany()
                .HasForeignKey(l => l.AssignedTo)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}