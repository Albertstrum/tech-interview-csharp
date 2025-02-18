using System.Text.Json;
using System;
using System.Text.Json.Serialization;
using Vehicles.Api.Models;
using System.Linq;

namespace Vehicles.Api.Repositories
{
    // TODO: Replace hardcoded file with a database
    // TODO: Add caching support
    public class VehiclesRepository : IVehiclesRepository
    {
        private readonly ILogger<VehiclesRepository> _logger;

        List<Vehicle> _vehicles;
        public VehiclesRepository(ILogger<VehiclesRepository> logger)
        {
            _logger = logger;
            _vehicles = new List<Vehicle>();

            try
            {
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading vehicles.json");
            }
        }

        public List<Vehicle> GetAll()
        {
            return _vehicles;
        }

        public List<Vehicle> GetByQuery(Vehicle vehicle)
        {
            var queriedVehicles = new List<Vehicle>();

            if (vehicle == null) { return queriedVehicles; }

            // TODO: Make generic, source properties from Vehicle class instead of hardcoding
            queriedVehicles = _vehicles.Where(v =>
                (vehicle.Price == default || v.Price == vehicle.Price) &&
                (string.IsNullOrEmpty(vehicle.Make) || v.Make == vehicle.Make) &&
                (string.IsNullOrEmpty(vehicle.Model) || v.Model == vehicle.Model) &&
                (string.IsNullOrEmpty(vehicle.Trim) || v.Trim == vehicle.Trim) &&
                (string.IsNullOrEmpty(vehicle.Colour) || v.Colour == vehicle.Colour) &&
                (vehicle.Co2Level == default || v.Co2Level == vehicle.Co2Level) &&
                (string.IsNullOrEmpty(vehicle.Transmission) || v.Transmission == vehicle.Transmission) &&
                (string.IsNullOrEmpty(vehicle.FuelType) || v.FuelType == vehicle.FuelType) &&
                (vehicle.EngineSize == default || v.EngineSize == vehicle.EngineSize) &&
                (vehicle.DateFirstReg == default || v.DateFirstReg == vehicle.DateFirstReg) &&
                (vehicle.Mileage == default || v.Mileage == vehicle.Mileage)
            ).ToList();

            return queriedVehicles;
        }
    }
}
