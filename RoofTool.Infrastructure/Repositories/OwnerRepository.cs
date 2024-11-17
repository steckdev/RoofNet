using Microsoft.EntityFrameworkCore;
using RoofTool.Domain.Entities;

namespace RoofTool.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly RoofToolDbContext _context;

        public OwnerRepository(RoofToolDbContext context)
        {
            _context = context;
        }

        public async Task<Owner> AddAsync(Owner owner)
        {
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
            return owner;
        }

        public async Task<Owner?> GetByIdAsync(Guid id)
        {
            return await _context.Owners
                .Include(o => o.Properties)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(Owner owner)
        {
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
        }
    }
}
