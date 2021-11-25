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
    public class OwnerController : ControllerBase
    {
        private readonly ILogger<OwnerController> _logger;
        private readonly IOwnerService _ownerService;

        public OwnerController( ILogger<OwnerController> logger,
                                IOwnerService ownerService)
        {
            this._logger = logger;
            this._ownerService = ownerService;
        }
        /// <summary>
        /// Get all owners form db
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAllOwner")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OwnerDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllOwner(Pagging paagging)
        {
            _logger.LogTrace($"Starting Controller {nameof(GetAllOwner)}");
            var result = await _ownerService.GetAllOwner(paagging);
            _logger.LogTrace($"End Controller {nameof(GetAllOwner)}");
            return Ok(result);
        }


        /// <summary>
        /// Create a new owner
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateOwner(OwnerDTO dtoOwner)
        {
            _logger.LogTrace($"Starting Controller {nameof(CreateOwner)}");
            await _ownerService.Create(dtoOwner);
            _logger.LogTrace($"End Controller {nameof(CreateOwner)}");
            return Ok();
        }


        /// <summary>
        /// Update Owner
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOwner(OwnerDTO owner)
        {
            _logger.LogTrace($"Starting Controller {nameof(CreateOwner)}");
            await _ownerService.Update(owner);
            _logger.LogTrace($"End Controller {nameof(CreateOwner)}");
            return Ok();
        }


        /// <summary>
        /// Delete Owner
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOwner(Guid idOwner)
        {
            _logger.LogTrace($"Starting Controller {nameof(DeleteOwner)}");
            await _ownerService.Delete(idOwner);
            _logger.LogTrace($"End Controller {nameof(DeleteOwner)}");
            return Ok();
        }
    }
}
