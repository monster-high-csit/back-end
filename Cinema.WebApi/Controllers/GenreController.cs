using Cinema.Entities;
using Cinema.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Cinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly ILogger<GenreController> _logger;
        private readonly IGenreService _genreService;
        public GenreController(ILogger<GenreController> logger, IGenreService genreService)
        {
            _logger = logger;
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Genre> filmMakers = new List<Genre>(_genreService.GetGenres());
            return Ok(filmMakers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Genre genre = _genreService.GetGenreByID(id);
            return Ok(genre);
        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            try
            {
                _genreService.Add(genre);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
