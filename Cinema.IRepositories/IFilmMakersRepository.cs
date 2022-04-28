using Cinema.Entities;
using System.Collections.Generic;

namespace Cinema.IRepositories
{
    public interface IFilmMakersRepository
    {
        FilmMaker GetFilmMakerByID(int id);
        int Add(FilmMaker filmMaker);
        int GetFilmStudioIDByName(string name, string surname);
        List<FilmMaker> GetFilmMakers();
    }
}
