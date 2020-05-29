using battleship.Models;
using System.Collections.Generic;
using System.Linq;

namespace battleship.Tests
{
    public static class MockData
    {
        public static string ErrorMessage = "\"failed to process request\"";
        public static string SuccessMessage = "\"successfully processed request\"";
        public static string HitMessage = "\"hit\"";
        public static string MissMessage = "\"miss\"";
        public static string Player1Id = "123";
        public static string Player2Id = "234";


        public static Ship GetMockShipPLayer1()
        {
            return new Ship() { PlayerId = Player1Id, Locations = GetValidMockLocations1() };
        }

        public static Shot GetHitShotFromBattlefield(Battlefield field)
        {
            var randomLocation = field.Boards.SelectMany(p => p.Ships).FirstOrDefault();
            return new Shot()
            {
                PlayerId = randomLocation.PlayerId,
                Column = randomLocation.Locations.FirstOrDefault().Column,
                Row = randomLocation.Locations.FirstOrDefault().Row
            };
        }

        public static Shot GetMissShotFromBattlefield(Battlefield field)
        {
            var randomLocation = field.Boards.SelectMany(p => p.Ships).FirstOrDefault();
            return new Shot()
            {
                PlayerId = randomLocation.PlayerId,
                Column = 0,
                Row = 0
            };
        }

        public static Ship GetMockShipPLayer2()
        {
            return new Ship() { PlayerId = Player2Id, Locations = GetValidMockLocations1() };
        }

        public static List<Ship> GetMockShipsValid()
        {
            return new List<Ship>()
            {
               new Ship() { PlayerId = Player1Id, Locations = GetValidMockLocations1() },
               new Ship() { PlayerId = Player1Id, Locations = GetValidMockLocations1() }
            };
        }

        public static List<Location> GetMockShipsInvalidShape()
        {
            return new List<Location>()
            {
                new Location() { Row = 1, Column = 2}, new Location() { Row = 1, Column = 3}, new Location() { Row = 2, Column = 3}
            };
        }

        public static Ship GetMockOversizeShip()
        {
            return new Ship()
            {
                Locations = new List<Location>()
            {
                new Location { Row = 4, Column = 1 },
                new Location { Row = 4, Column = 2 },
                new Location { Row = 4, Column = 3 },
                new Location { Row = 4, Column = 4 },
                new Location { Row = 4, Column = 5 },
                new Location { Row = 4, Column = 6 },
                new Location { Row = 4, Column = 7 },
                new Location { Row = 4, Column = 8 },
                new Location { Row = 4, Column = 9 },
                new Location { Row = 4, Column = 10 },
                new Location { Row = 4, Column = 11 }
            }
            };
        }

        public static List<Location> GetValidMockLocations1()
        {
            return new List<Location>() { new Location { Row = 4, Column = 5 }, new Location { Row = 4, Column = 6 } };
        }

        public static List<Location> GetOversizeLocations()
        {
            return new List<Location>() { new Location { Row = 11, Column = 11 }, new Location { Row = 0, Column = 12 } };
        }

        public static Shot GetMockShot()
        {
            return new Shot();
        }

        public static Battlefield GetMockBattlefield()
        {
            return new Battlefield()
            {
                Boards = new List<PlayerBoard>() {
                new PlayerBoard() { PlayerId = Player1Id, Ships = new List<Ship>{ GetMockShipPLayer1() } },
                new PlayerBoard() { PlayerId = Player2Id, Ships = new List<Ship>{  GetMockShipPLayer2() } }
            }
            };
        }
    }
}
