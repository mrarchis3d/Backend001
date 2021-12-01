using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace weelo_test_api.Controllers
{
    /// <summary>
    /// Controller for Property Traces
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PropertyTraceController : ControllerBase
    {
        private readonly ILogger<PropertyTraceController> _logger;
        private readonly IPropertyTraceService _propertyTraceService;

        public PropertyTraceController(ILogger<PropertyTraceController> logger,
                                IPropertyTraceService propertyTraceService)
        {
            _logger = logger;
            _propertyTraceService = propertyTraceService;
        }

        /// <summary>
        /// Create a new Property trace
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreatePropertyTrace(PropertyTrace propTrace)
        {
            _logger.LogTrace($"Starting Controller {nameof(CreatePropertyTrace)}");
            await _propertyTraceService.Create(propTrace);
            _logger.LogTrace($"End Controller {nameof(CreatePropertyTrace)}");
            return Ok();
        }

        /// <summary>
        /// Getting All traces from Property
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PropertyTrace>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPropertyTraces(Guid idProperty)
        {
            _logger.LogTrace($"Starting Controller {nameof(GetPropertyTraces)}");
            var result = await _propertyTraceService.GetPropertyTraces(idProperty);
            _logger.LogTrace($"End Controller {nameof(GetPropertyTraces)}");
            return Ok(result);
        }


        /// <summary>
        /// Update image from property set enabled
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTrace(PropertyTrace proptrace)
        {
            _logger.LogTrace($"Starting Controller {nameof(UpdateTrace)}");
            await _propertyTraceService.Update(proptrace);
            _logger.LogTrace($"End Controller {nameof(UpdateTrace)}");
            return Ok();
        }


        /// <summary>
        /// deleting image from property
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTrace(Guid idTrace)
        {
            _logger.LogTrace($"Starting Controller {nameof(DeleteTrace)}");
            await _propertyTraceService.Delete(idTrace);
            _logger.LogTrace($"End Controller {nameof(DeleteTrace)}");
            return Ok();
        }
    }
}
