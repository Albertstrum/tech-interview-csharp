using Microsoft.AspNetCore.Mvc;
using Vehicles.Api.Models;
using Vehicles.Api.Repositories;

namespace Vehicles.Api.Controllers
{
    // TODO: Add OAuth
    // TODO: Add Rate limiting to prevent abuse
    // TODO: Add API versioning
    // TODO: Add Swagger documentation (example response, request, etc.)
    // TODO: Pagination for large requests
    // TODO: Implement OData model and more query options (Price/year range, multiple colours/models, etc)
    [ApiController]
    [Route("[controller]/[action]")]
    public class VehiclesController : ControllerBase
    {
        private readonly ILogger<VehiclesController> _logger;
        private readonly IVehiclesRepository _vehiclesRepository;

        public VehiclesController(ILogger<VehiclesController> logger, IVehiclesRepository vehiclesRepository)
        {
            _logger = logger;
            _vehiclesRepository = vehiclesRepository;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Getting all vehicles");

            try
            {
                var vehicles = _vehiclesRepository.GetAll();

                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                var errorMsg = "An error occurred while getting all vehicles";
                _logger.LogError(ex, errorMsg);

                return StatusCode(500, errorMsg);
            }
        }

        [HttpGet]
        [ActionName("GetByQuery")]
        public IActionResult GetByQuery([FromQuery]Vehicle vehicle)
        {
            _logger.LogInformation("Getting vehicles by query");

            try
            {
                var filteredVehicles = _vehiclesRepository.GetByQuery(vehicle);

                return Ok(filteredVehicles);
            }
            catch (Exception ex)
            {
                var errorMsg = "An error occurred while getting vehicles by query";
                _logger.LogError(ex, errorMsg);

                return StatusCode(500, errorMsg);
            }
         }
    }
}