using Xunit;
using Moq;
using battleship.Services;
using battleship.Repositories;

namespace battleship.Tests
{
    public class BattlefieldServicesTest
    {
        [Fact]
        public void TestAttackHit()
        {
            var repoMock = new Mock<IMockRepository>();
            var battlefield = MockData.GetMockBattlefield();
            var shot = MockData.GetHitShotFromBattlefield(battlefield);
            repoMock.Setup(p => p.GetCurrentBattlefield()).Returns(battlefield);
            var service = new BattleFieldService(repoMock.Object);
            var success = service.Attack(shot);
            Assert.True(success);
        }

        [Fact]
        public void TestAttackMiss()
        {
            var repoMock = new Mock<IMockRepository>();
            var battlefield = MockData.GetMockBattlefield();
            var shot = MockData.GetMissShotFromBattlefield(battlefield);
            repoMock.Setup(p => p.GetCurrentBattlefield()).Returns(battlefield);
            var service = new BattleFieldService(repoMock.Object);
            var success = service.Attack(shot);
            Assert.False(success);
        }

        [Fact]
        public void TestAttackMis()
        {
            var repoMock = new Mock<IMockRepository>();
            repoMock.Setup(p => p.GetCurrentBattlefield()).Returns(MockData.GetMockBattlefield());
            var service = new BattleFieldService(repoMock.Object);
            var success = service.AddShip(MockData.GetMockShipPLayer1());
            Assert.True(success);
        }

        [Fact]
        public void TestAddShipSuccess()
        {
            var repoMock = new Mock<IMockRepository>();
            repoMock.Setup(p => p.GetCurrentBattlefield()).Returns(MockData.GetMockBattlefield());
            var service = new BattleFieldService(repoMock.Object);
            var success = service.AddShip(MockData.GetMockShipPLayer1());
            Assert.True(success);
        }

        [Fact]
        public void TestAddShipPLayer2Success()
        {
            var repoMock = new Mock<IMockRepository>();
            repoMock.Setup(p => p.GetCurrentBattlefield()).Returns(MockData.GetMockBattlefield());
            var service = new BattleFieldService(repoMock.Object);
            var success = service.AddShip(MockData.GetMockShipPLayer2());
            Assert.True(success);
        }

        [Fact]
        public void TestAddShipSuccesssNew()
        {
            var repoMock = new Mock<IMockRepository>();
            repoMock.Setup(p => p.GetCurrentBattlefield()).Returns(() => null);
            var service = new BattleFieldService(repoMock.Object);
            var success = service.AddShip(MockData.GetMockShipPLayer1());
            Assert.True(success);
        }

        [Fact]
        public void TestIsOversizeFail()
        {
            var service = new BattleFieldService(null);
            var invalid = service.IsOversize(MockData.GetOversizeLocations());
            Assert.True(invalid);
        }

        [Fact]
        public void TestIsIsCorrectLengthFail()
        {
            var service = new BattleFieldService(null);
            var valid = service.IsValidLength(MockData.GetMockShipsValid(), MockData.GetMockOversizeShip());
            Assert.False(valid);
        }

        [Fact]
        public void TestIsIsCorrectShapeFail()
        {
            var service = new BattleFieldService(null);
            var valid = service.IsValidAalignment(MockData.GetMockShipsInvalidShape());
            Assert.False(valid);
        }
    }
}
