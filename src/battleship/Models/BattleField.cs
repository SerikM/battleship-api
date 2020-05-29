using System.Collections.Generic;

namespace battleship.Models
{
    public class Battlefield
    {
        public List<PlayerBoard> Boards { get; set; }
        public string PlayerId { get; set; }
    }
}
