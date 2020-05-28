using battleship.Models;

namespace battleship.Services
{
    interface IBattleFieldService
    {
        public bool CreateNewBattlefield(Ship ship);
        public bool MakeShot(Shot shot);
    }
}
