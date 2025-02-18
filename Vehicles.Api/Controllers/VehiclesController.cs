using Microsoft.AspNetCore.Mvc;
using Vehicles.Api.Models;
using Vehicles.Api.Repositories;

namespace Vehicles.Api.Controllers
{
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

        // Pagination would be useful to avoid returning all vehicles in one big response
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

        // Replace with OData implementation for more advanced queries
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