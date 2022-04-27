using Cinema.Entities;
using Cinema.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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

        [HttpGet]
        public IActionResult Get()
        {
            List<FilmMaker> filmMakers = new List<FilmMaker>(_filmMakerService.GetFilmMakers());
            return Ok(filmMakers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            FilmMaker filmMaker = _filmMakerService.GetFilmMakerByID(id);
            return Ok(filmMaker);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int result = _filmMakerService.DeleteFilmMaker(id);
            if (result == 0)
            {
                return BadRequest("ERROR! FilmMaker isn't deleted");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(FilmMaker filmMaker)
        {
            try
            {
                //create filmmaker
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
