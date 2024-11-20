
using RoofTool.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RoofTool.Infrastructure.Interfaces
{
    public interface ILeadRepository
    {
        Task<Lead> AddAsync(Lead lead);
        Task<Lead?> GetByIdAsync(Guid id);
        Task UpdateAsync(Lead lead);
        Task DeleteAsync(Guid id);
    }
}