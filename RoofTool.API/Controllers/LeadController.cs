
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoofTool.Application.Interfaces;
using RoofTool.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RoofTool.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    public class LeadController : ControllerBase
    {
        private readonly ILeadService _service;

        public LeadController(ILeadService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLead(Lead lead)
        {
            var result = await _service.CreateLeadAsync(lead);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLead(Guid id)
        {
            var result = await _service.GetLeadByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLead(Guid id, Lead lead)
        {
            if (id != lead.Id)
            {
                return BadRequest();
            }

            await _service.UpdateLeadAsync(lead);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLead(Guid id)
        {
            await _service.DeleteLeadAsync(id);
            return NoContent();
        }
    }
}