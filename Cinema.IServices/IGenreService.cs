using Cinema.Entities;

namespace Cinema.IServices
{
    public interface IGenreService
    {
        Genre GetGenreByID(int id);
        int Add(Genre genre);
        int GetGenreIDByName(string name);
    }
}
