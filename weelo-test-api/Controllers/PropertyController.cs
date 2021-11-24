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
        private readonly IOwnerService _ownerService;

        public PropertyController(ILogger<PropertyController> logger,
                                IOwnerService ownerService)
        {
            this._logger = logger;
            this._ownerService = ownerService;
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
            var result = await _ownerService.GetAllOwner();
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
        public async Task<IActionResult> CreateProperty(OwnerDTO dtoOwner)
        {
            _logger.LogTrace($"Starting Controller {nameof(CreateProperty)}");
            await _ownerService.Create(dtoOwner);
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
        public async Task<IActionResult> UpdateProperty(OwnerDTO owner)
        {
            _logger.LogTrace($"Starting Controller {nameof(UpdateProperty)}");
            await _ownerService.Update(owner);
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
            await _ownerService.Delete(idProperty);
            _logger.LogTrace($"End Controller {nameof(DeleteProperty)}");
            return Ok();
        }
    }
}
