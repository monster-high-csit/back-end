using System.ComponentModel.DataAnnotations;

namespace Cinema.Entities
{
    public class FilmStudio
    {
        public int StudioID { get; set; }

        [StringLength(100, ErrorMessage = "Length is bigger than 100.")]
        [Required]
        public string Name { get; set; }
    }
}
