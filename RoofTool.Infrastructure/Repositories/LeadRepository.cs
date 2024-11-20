
using Microsoft.EntityFrameworkCore;
using RoofTool.Domain.Entities;
using RoofTool.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace RoofTool.Infrastructure.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly RoofToolDbContext _context;

        public LeadRepository(RoofToolDbContext context)
        {
            _context = context;
        }

        public async Task<Lead> AddAsync(Lead lead)
        {
            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();
            return lead;
        }

        public async Task<Lead?> GetByIdAsync(Guid id)
        {
            return await _context.Leads.FindAsync(id);
        }

        public async Task UpdateAsync(Lead lead)
        {
            _context.Leads.Update(lead);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead != null)
            {
                _context.Leads.Remove(lead);
                await _context.SaveChangesAsync();
            }
        }
    }
}