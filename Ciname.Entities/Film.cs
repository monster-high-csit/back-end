using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities
{
    public class Film
    {
        public int FilmID { get; set; }
        public int GengreID { get; set; }
        public int StudioID { get; set; }
        public int FilmmakerID{ get; set; }
        public string Name { get; set; }
        public byte AgeLimit { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int Rating { get; set; }
        public DateTime Duration { get; set; }
    }
}
