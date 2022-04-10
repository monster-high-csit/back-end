using Cinema.Entities;

namespace Cinema.IServices
{
    public interface IFilmService
    {
        Film GetFilm(int id);
        int DeleteFilm(int id);
        void CreateFilm(Film film);
    }
}
