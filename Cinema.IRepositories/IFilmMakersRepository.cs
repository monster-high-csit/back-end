using Cinema.Entities;

namespace Cinema.IRepositories
{
    public interface IFilmMakersRepository
    {
        FilmMaker GetFilmMakerByID(int id);
        int Add(FilmMaker filmMaker);
        int GetFilmStudioIDByName(string name, string surname);
    }
}
