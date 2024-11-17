using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoofTool.Application.Interfaces;
using RoofTool.Domain.Entities;
using RoofTool.Domain.Enums;

namespace RoofTool.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    public class OpportunityController : ControllerBase
    {
        private readonly IOpportunityService _service;

        public OpportunityController(IOpportunityService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOpportunity(Opportunity opportunity)
        {
            var result = await _service.CreateOpportunityAsync(opportunity);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOpportunity(Guid id)
        {
            var result = await _service.GetOpportunityByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] OpportunityStatus status)
        {
            await _service.UpdateOpportunityStatusAsync(id, status);
            return NoContent();
        }
    }
}