using Cinema.Entities;
using System.Collections.Generic;

namespace Cinema.IRepositories
{
    public interface IGenreRepository
    {
        Genre GetGenreByID(int id);
        int Add(Genre genre);
        int GetGenreIDByName(string name);
        List<Genre> GetGenres();
    }
}
