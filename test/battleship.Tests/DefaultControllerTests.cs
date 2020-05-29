using Xunit;
using Moq;
using battleship.Services;
using battleship.Controllers;
using battleship.Models;
using Microsoft.AspNetCore.Mvc;

namespace battleship.Tests
{
    public class DefaultControllerTests
    {
        [Fact]
        public void TestInitialize()
        {
            var serviceMock = new Mock<IBattleFieldService>();
            serviceMock.Setup(p => p.AddShip(It.IsAny<Ship>())).Returns(() => true);
            var mockController = new DefaultController(serviceMock.Object);
            var response = mockController.Initialize(MockData.GetMockShipPLayer1()) as OkObjectResult;
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(MockData.SuccessMessage, response.Value);
        }

        [Fact]
        public void TestShoot()
        {
            var serviceMock = new Mock<IBattleFieldService>();
            serviceMock.Setup(p => p.Attack(It.IsAny<Shot>())).Returns(() => true);
            var mockController = new DefaultController(serviceMock.Object);
            var response = mockController.Shoot(MockData.GetMockShot()) as OkObjectResult;
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(MockData.HitMessage, response.Value);
        }
    }
}
