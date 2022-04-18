using Cinema.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Entities
{
    public class FilmMaker
    {
        private string _name;
        private string _surname;

        public int FilmMakerId { get; set; }

        [StringLength(30, ErrorMessage = "Length is bigger than 30.")]
        [Required]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!value.ConsistOnlyFIO())
                {
                    throw new ArgumentException("Incorrect name.");
                }
                _name = value;
            }
        }

        [StringLength(40, ErrorMessage = "Length is bigger than 40.")]
        [Required]
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (!value.ConsistOnlyFIO())
                {
                    throw new ArgumentException("Incorrect surname.");
                }
                _surname = value;
            }
        }
    }
}
