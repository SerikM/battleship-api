using battleship.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace battleship.Services
{
    public class BattleFieldService : IBattleFieldService
    {
        private const int MaxBoardSize = 10;
        private Battlefield Battlefield { get; set; }


        public bool MakeShot(Shot shot)
        {
            var board = GetPlayerBoard(shot.PlayerId);
            if (board == null) return false;
            
            var location = board.Ships.SelectMany(p => p.Locations).FirstOrDefault(d => d.Row == shot.Row && d.Column == shot.Column);
            if (location == null)
            {
                location.Miss = true;
                return false;
            }

            return location.Hit = true;
        }

        public bool CreateNewBattlefield(Ship newShip)
        {
            if (Battlefield == null)
            {
                Battlefield = new Battlefield()
                {
                    Boards = new List<PlayerBoard>()
                            {
                                new PlayerBoard()
                                {
                                    PlayerId = newShip.PlayerId,
                                    Ships = new List<Ship>
                                    {
                                        newShip
                                    }
                                },
                                new PlayerBoard()
                            }
                };
            }
            else
            {
                var board = GetPlayerBoard(newShip?.PlayerId);
                if (board == null) return false;
                if (!CanAddShip(board, newShip)) return false;
                board.Ships.Add(newShip);
            }
            return true;
        }

        private bool CanAddShip(PlayerBoard board, Ship newShip)
        {
            bool correctSize = IsCorrectSize(board.Ships, newShip);
            if (!correctSize) return false;
            bool correctShape = IsCorrectShape(newShip.Locations);
            if (!correctShape) return false;
            bool isOversize = IsOversize(newShip.Locations);
            if (isOversize) return false;
            return HasNeighbouringCells(board.Ships, newShip.Locations);
        }

        private bool IsOversize(List<Location> locations)
        {
            return locations.Any(p => p.Column > MaxBoardSize || p.Column <= 0 || p.Row > MaxBoardSize || p.Row <= 0);
        }

        private bool IsCorrectSize(List<Ship> ships, Ship ship)
        {
            var sizeOK = ship.Locations.Any() && ship.Locations.Count <= MaxBoardSize;
            if (!sizeOK) return false;
            return ships.Select(p => p.Locations).Count() + ship.Locations.Count <= Math.Pow(MaxBoardSize, 2);
        }

        private bool HasNeighbouringCells(List<Ship> ships, List<Location> locations)
        {
            //:TO:DO implement logic using Connected-component labeling
            return false;
        }

        private bool IsCorrectShape(List<Location> locations)
        {
            bool rowsAligned = locations.Select(p => p.Row).Distinct().Count() == 1;
            bool colsAligned = locations.Select(p => p.Column).Distinct().Count() == 1;
            return rowsAligned || colsAligned;
        }

        private PlayerBoard GetPlayerBoard(string playeId)
        {
            return Battlefield.Boards.FirstOrDefault(p => p.PlayerId == playeId);
        }
    }
}
