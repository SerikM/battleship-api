using battleship.Models;

namespace battleship.Services
{
    public interface IBattleFieldService
    {
        public bool AddShip(Ship ship);
        public bool Attack(Shot shot);
    }
}
