using System.Collections.Generic;

namespace Cinema.Entities
{
    public class Film
    {
        public int FilmID { get; set; }
        public string Genre { get; set; }
        public string FilmStudio { get; set; }
        public string Filmmaker{ get; set; }
        public string Name { get; set; }
        public byte AgeLimit { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int Rating { get; set; }
        public int Duration { get; set; }
        public List<Actor> actors { get; set; }
    }
}
