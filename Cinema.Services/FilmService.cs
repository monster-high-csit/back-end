using AutoMapper;
using Cinema.Dto;
using Cinema.Entities;
using Cinema.IRepositories;
using Cinema.IServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Services
{
    public class FilmService : IFilmService
    {
        private readonly ILogger<FilmService> _logger;
        private readonly IFilmRepository _filmRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IFilmMakersRepository _filmMakersRepository;
        private readonly IFilmStudioRepository _filmStudioRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public FilmService(ILogger<FilmService> logger, IFilmRepository filmRepository, IMapper mapper, IActorRepository actorRepository,
            IFilmMakersRepository filmMakersRepository, IFilmStudioRepository filmStudioRepository, IGenreRepository genreRepository)
        {
            _logger = logger;
            _filmRepository = filmRepository;
            _actorRepository = actorRepository;
            _filmMakersRepository = filmMakersRepository;
            _filmStudioRepository = filmStudioRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public int DeleteFilm(int id)
        {
            return _filmRepository.DeleteFilm(id);
        }

        public Film GetFilm(int id)
        {
            var filmDto = _filmRepository.GetFilm(id);
            var film = _mapper.Map<Film>(filmDto);
            var filmMaker = _filmMakersRepository.GetFilmMakerByID(filmDto.FilmmakerID);
            film.Filmmaker = $"{filmMaker.SurName} {filmMaker.Name[0]}.";
            film.Genre = _genreRepository.GetGenreByID(filmDto.GenreID).Name;
            film.FilmStudio = _filmStudioRepository.GetFilmStudioByID(filmDto.FilmStudioID).Name;
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
                throw new Exception();
            }
        }
    }
}
