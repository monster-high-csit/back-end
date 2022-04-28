using Cinema.Entities;
using Cinema.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Cinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly ILogger<HallController> _logger;
        private readonly IHallService _hallService;
        public HallController(ILogger<HallController> logger, IHallService hallService)
        {
            _logger = logger;
            _hallService = hallService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Hall> actors = new List<Hall>(_hallService.GetHalls());
            return Ok(actors);
        }
    }
}
