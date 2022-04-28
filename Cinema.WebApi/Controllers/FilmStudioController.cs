using Cinema.Entities;
using Cinema.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Cinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmStudioController : ControllerBase
    {
        private readonly ILogger<FilmStudioController> _logger;
        private readonly IFilmStudioService _filmStudioService;
        public FilmStudioController(ILogger<FilmStudioController> logger, IFilmStudioService filmStudioService)
        {
            _logger = logger;
            _filmStudioService = filmStudioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<FilmStudio> filmMakers = new List<FilmStudio>(_filmStudioService.GetFilmStudios());
            return Ok(filmMakers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            FilmStudio filmStudio = _filmStudioService.GetFilmStudioByID(id);
            return Ok(filmStudio);
        }

        [HttpPost]
        public IActionResult Create(FilmStudio filmStudio)
        {
            try
            {
                _filmStudioService.Add(filmStudio);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
