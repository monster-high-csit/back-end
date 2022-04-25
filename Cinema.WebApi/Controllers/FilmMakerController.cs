using Cinema.Entities;
using Cinema.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmMakerController : ControllerBase
    {
        private readonly ILogger<FilmMakerController> _logger;
        private readonly IFilmMakersService _filmMakerService;
        public FilmMakerController(ILogger<FilmMakerController> logger, IFilmMakersService filmMakerService)
        {
            _logger = logger;
            _filmMakerService = filmMakerService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            FilmMaker filmMaker = _filmMakerService.GetFilmMakerByID(id);
            return Ok(filmMaker);
        }
    }
}
