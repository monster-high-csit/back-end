using Cinema.Entities;
using Cinema.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Cinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly ILogger<ActorController> _logger;
        private readonly IActorService _actorService;
        public ActorController(ILogger<ActorController> logger, IActorService actorService)
        {
            _logger = logger;
            _actorService = actorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Actor> actors = new List<Actor>(_actorService.GetActors());
            return Ok(actors);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Actor actor = _actorService.GetActor(id);
            return Ok(actor);
        }

        [HttpPost]
        public IActionResult Create(Actor actor)
        {
            try
            {
                _actorService.CreateActor(actor);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
