using Cinema.Entities;
using System.Collections.Generic;

namespace Cinema.IServices
{
    public interface IFilmStudioService
    {
        FilmStudio GetFilmStudioByID(int id);
        int Add(FilmStudio filmStudio);
        int GetFilmStudioIDByName(string name);
        List<FilmStudio> GetFilmStudios();
    }
}
