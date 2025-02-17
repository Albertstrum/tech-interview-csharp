using Vehicles.Api.Models;

namespace Vehicles.Api.Repositories
{
    public interface IVehiclesRepository
    {
        List<Vehicle> GetAll();
    }
}