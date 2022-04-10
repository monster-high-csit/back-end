using Cinema.Entities;
using Cinema.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly ILogger<FilmController> _logger;
        private readonly IFilmService _filmService;
        public FilmController(ILogger<FilmController> logger, IFilmService filmService)
        {
            _logger = logger;
            _filmService = filmService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Film film = _filmService.GetFilm(id);
            return Ok(film);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int result = _filmService.DeleteFilm(id);
            if (result == 0)
            {
                return BadRequest("ERROR! Film isn't deleted");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(Film film)
        {
            try
            {
                _filmService.CreateFilm(film);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
