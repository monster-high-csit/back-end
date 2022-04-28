using Cinema.Entities;
using System.Collections.Generic;

namespace Cinema.IServices
{
    public interface IGenreService
    {
        Genre GetGenreByID(int id);
        int Add(Genre genre);
        int GetGenreIDByName(string name);
        List<Genre> GetGenres();
    }
}
