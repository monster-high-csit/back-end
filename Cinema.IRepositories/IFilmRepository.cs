using Cinema.Dto;
using System.Collections.Generic;

namespace Cinema.IRepositories
{
    public interface IFilmRepository
    {
        FilmDto GetFilm(int id);
        int DeleteFilm(int id);
        void CreateFilm(FilmDto filmDto);
        List<FilmDto> GetFilms();
    }
}
