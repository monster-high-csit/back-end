
using Cinema.Entities;
using Cinema.IRepositories;
using Cinema.IServices;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Cinema.Services
{
    public class GenreService : IGenreService
    {
        private readonly ILogger<GenreService> _logger;
        private readonly IGenreRepository _genreRepository;
        public GenreService(ILogger<GenreService> logger, IGenreRepository genreRepository)
        {
            _logger = logger;
            _genreRepository = genreRepository;
        }

        public int Add(Genre genre)
        {
            return _genreRepository.Add(genre);
        }

        public Genre GetGenreByID(int id)
        {
            return _genreRepository.GetGenreByID(id);
        }

        public int GetGenreIDByName(string name)
        {
            return _genreRepository.GetGenreIDByName(name);
        }

        public List<Genre> GetGenres()
        {
            return _genreRepository.GetGenres();
        }
    }
}
