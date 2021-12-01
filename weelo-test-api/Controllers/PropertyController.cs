using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Dtos;
using Models.Utils;
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
        /// Get all properties with owner description
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAllPropertyWithOwner")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PropertyWithOwnerDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllPropertyWithOwner(Pagging pagging)
        {
            _logger.LogTrace($"Starting Controller {nameof(GetAllPropertyWithOwner)}");
            var result = await _propertyService.GetAllPropertyWithOwner(pagging);
            _logger.LogTrace($"End Controller {nameof(GetAllPropertyWithOwner)}");
            return Ok(result);
        }


        /// <summary>
        /// create property
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
        /// Update Property
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
        /// Delete property
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
