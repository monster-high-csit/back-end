
using Cinema.Entities;
using Cinema.IRepositories;
using Cinema.IServices;
using Microsoft.Extensions.Logging;

namespace Cinema.Services
{
    public class FilmStudioService : IFilmStudioService
    {
        private readonly ILogger<FilmStudioService> _logger;
        private readonly IFilmStudioRepository _filmStudioRepository;
        public FilmStudioService(ILogger<FilmStudioService> logger, IFilmStudioRepository filmStudioRepository)
        {
            _logger = logger;
            _filmStudioRepository = filmStudioRepository;
        }

        public int Add(FilmStudio filmStudio)
        {
            return _filmStudioRepository.Add(filmStudio);
        }

        public FilmStudio GetFilmStudioByID(int id)
        {
            return _filmStudioRepository.GetFilmStudioByID(id);
        }

        public int GetFilmStudioIDByName(string name)
        {
            return _filmStudioRepository.GetFilmStudioIDByName(name);
        }
    }
}
