using AutoMapper;
using Cinema.Dto;
using Cinema.Entities;
using Cinema.IRepositories;
using Cinema.IServices;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Services
{
    public class FilmService : IFilmService
    {
        private readonly ILogger<FilmService> _logger;
        private readonly IFilmRepository _filmRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;

        public FilmService(ILogger<FilmService> logger, IFilmRepository filmRepository, IMapper mapper, IActorRepository actorRepository)
        {
            _logger = logger;
            _filmRepository = filmRepository;
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public int DeleteFilm(int id)
        {
            return _filmRepository.DeleteFilm(id);
        }

        public Film GetBook(int id)
        {
            var film = _mapper.Map<Film>(_filmRepository.GetBook(id));
            var actorsFilm = _actorRepository.GetActorByFilmIDs(new List<int>(){ film.FilmID });
            film.actors = actorsFilm;
            return film;
        }

        public void CreateFilm(Film film)
        {
            try
            {
                FilmDto filmDto = _mapper.Map<FilmDto>(film);
                _filmRepository.CreateFilm(filmDto);
            }
            catch
            {
                
            }
        }
    }
}
