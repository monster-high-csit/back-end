
using Cinema.Entities;
using Cinema.IRepositories;
using Cinema.IServices;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Cinema.Services
{
    public class FilmMakerService : IFilmMakersService
    {
        private readonly ILogger<FilmMakerService> _logger;
        private readonly IFilmMakersRepository _filmMakerRepository;
        public FilmMakerService(ILogger<FilmMakerService> logger, IFilmMakersRepository filmMakerRepository)
        {
            _logger = logger;
            _filmMakerRepository = filmMakerRepository;
        }

        public int Add(FilmMaker filmMaker)
        {
            return _filmMakerRepository.Add(filmMaker);
        }

        public int DeleteFilmMaker(int id)
        {
            return _filmMakerRepository.DeleteFilmMaker(id);
        }

        public FilmMaker GetFilmMakerByID(int id)
        {
            return _filmMakerRepository.GetFilmMakerByID(id);
        }

        public List<FilmMaker> GetFilmMakers()
        {
            return _filmMakerRepository.GetFilmMakers();
        }

        public int GetFilmStudioIDByName(string name, string surname)
        {
            return _filmMakerRepository.GetFilmStudioIDByName(name, surname);
        }
    }
}
