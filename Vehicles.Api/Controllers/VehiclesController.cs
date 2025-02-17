using Microsoft.AspNetCore.Mvc;
using Vehicles.Api.Repositories;

namespace Vehicles.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly ILogger<VehiclesController> _logger;
        private readonly IVehiclesRepository _vehiclesRepository;

        public VehiclesController(ILogger<VehiclesController> logger, IVehiclesRepository vehiclesRepository)
        {
            _logger = logger;
            _vehiclesRepository = vehiclesRepository;
        }
    }
}