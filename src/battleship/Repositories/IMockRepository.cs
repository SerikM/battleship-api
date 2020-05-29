using battleship.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace battleship.Repositories
{
    public interface IMockRepository
    {
        public Battlefield GetCurrentBattlefield();
        public void SetBattleField(Battlefield battlefield);
    }
}
