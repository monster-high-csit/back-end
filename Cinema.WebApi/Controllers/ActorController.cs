using Cinema.Entities;
using Cinema.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Actor actor = _actorService.GetActor(id);
            return Ok(actor);
        }
    }
}
