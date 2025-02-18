using Vehicles.Api.Models;

namespace Vehicles.Api.Repositories
{
    public interface IVehiclesRepository
    {
        List<Vehicle> GetAll();
        List<Vehicle> GetByQuery(Vehicle vehicle);
    }
}