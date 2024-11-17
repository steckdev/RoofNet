using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoofTool.Application.Interfaces;
using RoofTool.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RoofTool.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementService _service;
        private readonly ILogger<MeasurementController> _logger;

        public MeasurementController(IMeasurementService service, ILogger<MeasurementController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddMeasurement(Measurement measurement)
        {
            _logger.LogInformation("AddMeasurement called with measurement: {Measurement}", measurement);
            var result = await _service.AddMeasurementAsync(measurement);
            return Ok(result);
        }

        [HttpGet("{propertyId}")]
        public async Task<IActionResult> GetMeasurementByPropertyId(Guid propertyId)
        {
            _logger.LogInformation("GetMeasurementByPropertyId called with propertyId: {PropertyId}", propertyId);
            var result = await _service.GetMeasurementByPropertyIdAsync(propertyId);
            return Ok(result);
        }
    }
}