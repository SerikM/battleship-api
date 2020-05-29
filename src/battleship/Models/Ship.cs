using System.Collections.Generic;

namespace battleship.Models
{
    public class Ship
    {
        public Ship() { }
        public List<Location> Locations { get; set; }
        public string PlayerId { get; set; }
    }
}