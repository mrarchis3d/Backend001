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
    /// Controller for Property Images
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PropertyImageController : ControllerBase
    {
        private readonly ILogger<PropertyImageController> _logger;
        private readonly IPropertyImageService _propertyImageService;

        public PropertyImageController(ILogger<PropertyImageController> logger,
                                IPropertyImageService propertyImageService)
        {
            _logger = logger;
            _propertyImageService = propertyImageService;
        }
        /// <summary>
        /// Getting All image from Property, get all set true when you like get all with enabled in false
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PropertyImage>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetImagesProperty(bool getAll, Guid idProperty)
        {
            _logger.LogTrace($"Starting Controller {nameof(GetImagesProperty)}");
            var result = await _propertyImageService.GetAllPropertyImages(getAll, idProperty);
            _logger.LogTrace($"End Controller {nameof(GetImagesProperty)}");
            return Ok(result);
        }


        /// <summary>
        /// Update image from property set enabled
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateImage(bool enabled, Guid idImage)
        {
            _logger.LogTrace($"Starting Controller {nameof(UpdateImage)}");
            await _propertyImageService.Update(enabled, idImage);
            _logger.LogTrace($"End Controller {nameof(UpdateImage)}");
            return Ok();
        }


        /// <summary>
        /// deleting image from property
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProperty(Guid idImage)
        {
            _logger.LogTrace($"Starting Controller {nameof(DeleteProperty)}");
            await _propertyImageService.Delete(idImage);
            _logger.LogTrace($"End Controller {nameof(DeleteProperty)}");
            return Ok();
        }
    }
}
