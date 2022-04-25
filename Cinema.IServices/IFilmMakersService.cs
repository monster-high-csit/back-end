
using Cinema.Entities;

namespace Cinema.IServices
{
    public interface IFilmMakersService
    {
        FilmMaker GetFilmMakerByID(int id);
        int Add(FilmMaker filmMaker);
        int GetFilmStudioIDByName(string name, string surname);
    }
}
