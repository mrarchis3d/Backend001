using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Dtos;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace weelo_test_api.Controllers
{
    /// <summary>
    /// Controller for Owners
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly ILogger<PropertyController> _logger;
        private readonly IPropertyService _propertyService;

        public PropertyController(ILogger<PropertyController> logger,
                                IPropertyService propertyService)
        {
            _logger = logger;
            _propertyService = propertyService;
        }
        /// <summary>
        /// Getting All parameters for calling News API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OwnerDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllProperties()
        {
            _logger.LogTrace($"Starting Controller {nameof(GetAllProperties)}");
            var result = await _propertyService.GetAllProperties();
            _logger.LogTrace($"End Controller {nameof(GetAllProperties)}");
            return Ok(result);
        }


        /// <summary>
        /// Getting All parameters for calling News API
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateProperty(PropertyDTO propertyDto)
        {
            _logger.LogTrace($"Starting Controller {nameof(CreateProperty)}");
            await _propertyService.Create(propertyDto);
            _logger.LogTrace($"End Controller {nameof(CreateProperty)}");
            return Ok();
        }


        /// <summary>
        /// Getting All parameters for calling News API
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProperty(PropertyDTO propertyDto)
        {
            _logger.LogTrace($"Starting Controller {nameof(UpdateProperty)}");
            await _propertyService.Update(propertyDto);
            _logger.LogTrace($"End Controller {nameof(UpdateProperty)}");
            return Ok();
        }


        /// <summary>
        /// Getting All parameters for calling News API
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProperty(Guid idProperty)
        {
            _logger.LogTrace($"Starting Controller {nameof(DeleteProperty)}");
            await _propertyService.Delete(idProperty);
            _logger.LogTrace($"End Controller {nameof(DeleteProperty)}");
            return Ok();
        }
    }
}
