namespace battleship.Models
{
    public class Location
    {
        public Location() { }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Hit { get; set; }
        public bool Miss { get; set; }
    }
}