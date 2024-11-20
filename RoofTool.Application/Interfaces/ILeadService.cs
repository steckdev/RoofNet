
using RoofTool.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RoofTool.Application.Interfaces
{
    public interface ILeadService
    {
        Task<Lead> CreateLeadAsync(Lead lead);
        Task<Lead> GetLeadByIdAsync(Guid id);
        Task UpdateLeadAsync(Lead lead);
        Task DeleteLeadAsync(Guid id);
    }
}