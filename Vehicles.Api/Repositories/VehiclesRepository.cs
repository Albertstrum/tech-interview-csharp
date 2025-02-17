using System.Text.Json;
using System;
using System.Text.Json.Serialization;
using Vehicles.Api.Models;

namespace Vehicles.Api.Repositories
{

    public class VehiclesRepository : IVehiclesRepository
    {
        private readonly ILogger<VehiclesRepository> _logger;

        List<Vehicle> _vehicles;
        public VehiclesRepository(ILogger<VehiclesRepository> logger)
        {
            _logger = logger;

            using (StreamReader r = new StreamReader("Repositories/vehicles.json"))
            {
                string json = r.ReadToEnd();
                var options = new JsonSerializerOptions
                {
                    Converters = { new Models.Converters.DateTimeConverter() }
                };
                _vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json) ?? new List<Vehicle>();
            }
        }

        public List<Vehicle> GetAll()
        {
            return _vehicles;
        }
    }
}
