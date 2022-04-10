namespace Cinema.Dto
{
    public class FilmDto
    {
        public int FilmID { get; set; }
        public int GenreID { get; set; }
        public int FilmStudioID { get; set; }
        public int FilmmakerID { get; set; }
        public string Name { get; set; }
        public byte AgeLimit { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int Rating { get; set; }
        public int Duration { get; set; }
    }
}
