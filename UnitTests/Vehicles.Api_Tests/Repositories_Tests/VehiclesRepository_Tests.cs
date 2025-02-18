using Microsoft.Extensions.Logging;
using Moq;
using Vehicles.Api.Models;
using Vehicles.Api.Repositories;

namespace UnitTests
{
    public class VehiclesRepository_Tests
    {
        private readonly Mock<ILogger<VehiclesRepository>> _loggerMock;
        private readonly VehiclesRepository _repository;

        public VehiclesRepository_Tests()
        {
            _loggerMock = new Mock<ILogger<VehiclesRepository>>();
            _repository = new VehiclesRepository(_loggerMock.Object);
        }

        [Fact]
        public void GetAll_CallRepo_ReturnAllVehicles()
        {
            var expectedVehicles = 780;

            var vehicles = _repository.GetAll();

            Assert.Equal(expectedVehicles, vehicles.Count);
        }

        [Fact]
        public void GetByQuery_FilterByMake_ReturnsCorrectVehicles()
        {
            var testVehicle = new Vehicle { Make = "BMW" };
            var expectedVehicles = 82;

            var vehicles = _repository.GetByQuery(testVehicle);

            Assert.Equal(expectedVehicles, vehicles.Count);
            Assert.True(vehicles.All(v => v.Make == testVehicle.Make));
        }

        [Fact]
        public void GetByQuery_MakeIsWrongCase_ReturnsNoMatches()
        {
            var testVehicle = new Vehicle { Make = "bmw" };
            var expectedVehicles = 0;

            var vehicles = _repository.GetByQuery(testVehicle);

            Assert.Equal(expectedVehicles, vehicles.Count);
        }
    }
}
