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

            var vehicles = _vehiclesRepository.GetAll();

            return Ok(vehicles);
        }

        // Replace with OData implementation for more advanced queries
        [HttpGet]
        [ActionName("GetByQuery")]
        public IActionResult GetByQuery([FromQuery]Vehicle vehicle)
        {
            _logger.LogInformation("Getting vehicles by query");

            var filteredVehicles = _vehiclesRepository.GetByQuery(vehicle);

            return Ok(filteredVehicles);
        }
    }
}