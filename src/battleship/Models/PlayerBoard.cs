using System.Collections.Generic;

namespace battleship.Models
{
    public class PlayerBoard
    {
        public string PlayerId { get; set; }
        public List<Ship> Ships { get; set; }
    }
}
