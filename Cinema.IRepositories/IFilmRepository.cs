using Cinema.Dto;

namespace Cinema.IRepositories
{
    public interface IFilmRepository
    {
        FilmDto GetFilm(int id);
        int DeleteFilm(int id);
        void CreateFilm(FilmDto filmDto);
    }
}
