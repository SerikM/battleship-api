namespace battleship.Models
{
    public class Shot
    {
        public Shot() { }
        public int Row { get; set; }
        public int Column { get; set; }
        public string PlayerId { get; set; }
    }
}