using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Vehicles.Api.Controllers;
using Vehicles.Api.Models;
using Vehicles.Api.Repositories;

namespace UnitTests.Controllers
{
    public class VehiclesController_Tests
    {
        private readonly Mock<ILogger<VehiclesController>> _loggerMock;
        private readonly Mock<IVehiclesRepository> _repositoryMock;
        private readonly VehiclesController _controller;

        public VehiclesController_Tests()
        {
            _loggerMock = new Mock<ILogger<VehiclesController>>();
            _repositoryMock = new Mock<IVehiclesRepository>();
            _controller = new VehiclesController(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public void GetAll_IsCalled_ReturnsOkResultWithAllVehicles()
        {
            var testVehicles = GetTestVehicles();
            _repositoryMock.Setup(repo => repo.GetAll()).Returns(testVehicles);

            var result = _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Vehicle>>(okResult.Value);
            Assert.Equal(testVehicles.Count, returnValue.Count);
        }

        [Fact]
        public void GetByQuery_ColourQuery_ReturnsOkResultWithCorrectVehicles()
        {
            var testVehicle = new Vehicle { Colour = "Alpine white" };
            var testVehicles = GetTestVehicles().FindAll(v => v.Colour == "Alpine white");
            _repositoryMock.Setup(repo => repo.GetByQuery(testVehicle)).Returns(testVehicles);

            var result = _controller.GetByQuery(testVehicle);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Vehicle>>(okResult.Value);
            Assert.Equal(testVehicles.Count, returnValue.Count);
        }

        private List<Vehicle> GetTestVehicles()
        {
            return new List<Vehicle>
            {
                new Vehicle { Price = 12999, Make = "BMW", Model = "1 SERIES", Trim = "118d SE 5dr [Nav]", Colour = "Alpine white", Co2Level = 104, Transmission = "Manual", FuelType = "Diesel", EngineSize = 1995, DateFirstReg = new DateTime(2017, 12, 28), Mileage = 11271 },
                new Vehicle { Price = 14699, Make = "BMW", Model = "1 SERIES", Trim = "118d M Sport 5dr [Nav]", Colour = "Melbourne red", Co2Level = 114, Transmission = "Manual", FuelType = "Diesel", EngineSize = 1995, DateFirstReg = new DateTime(2017, 10, 4), Mileage = 13324 }
            };
        }
    }
}