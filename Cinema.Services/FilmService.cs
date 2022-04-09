using Cinema.Entities;
using Cinema.IRepositories;
using Cinema.IServices;
using Microsoft.Extensions.Logging;

namespace Cinema.Services
{
    public class FilmService : IFilmService
    {
        private readonly ILogger<FilmService> _logger;
        private readonly IFilmRepository _filmRepository;
        public FilmService(ILogger<FilmService> logger, IFilmRepository filmRepository)
        {
            _logger = logger;
            _filmRepository = filmRepository;
        }
        public Film GetBook(int id)
        {
            return _filmRepository.GetBook(id);
        }
    }
}
