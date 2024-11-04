using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoofTool.Application.Interfaces;
using RoofTool.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RoofTool.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementService _service;

        public MeasurementController(IMeasurementService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddMeasurement(Measurement measurement)
        {
            var result = await _service.AddMeasurementAsync(measurement);
            return Ok(result);
        }

        [HttpGet("{propertyId}")]
        public async Task<IActionResult> GetMeasurementByPropertyId(Guid propertyId)
        {
            var result = await _service.GetMeasurementByPropertyIdAsync(propertyId);
            return Ok(result);
        }
    }
}