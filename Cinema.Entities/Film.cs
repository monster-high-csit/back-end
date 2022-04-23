using Cinema.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Entities
{
    public class Film
    {
        private int _rating;
        private int _duration;

        public int FilmID { get; set; }
        public string Genre { get; set; }
        public string FilmStudio { get; set; }
        public string Filmmaker{ get; set; }

        [StringLength(100, ErrorMessage = "Length is bigger than 100.")]
        [Required]
        public string Name { get; set; }
        public byte AgeLimit { get; set; }

        [StringLength(500, ErrorMessage = "Length is bigger than 500.")]
        [Required]
        public string Description { get; set; }

        [StringLength(250, ErrorMessage = "Length is bigger than 250.")]
        [Required]
        public string ShortDescription { get; set; }
        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                if (!value.IsCorrectRating())
                {
                    throw new ArgumentException("Incorrect rating.");
                }
                _rating = value;
            }
        }
        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                if (!value.IsCorrectDuration())
                {
                    throw new ArgumentException("Incorrect duration.");
                }
                _duration = value;
            }
        }
        public List<Actor> actors { get; set; }
    }
}
