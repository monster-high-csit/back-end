using Cinema.Entities;
using Cinema.IRepositories;
using Cinema.IServices;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Cinema.Services
{
    public class HallService : IHallService
    {
        private readonly ILogger<HallService> _logger;
        private readonly IHallRepository _hallRepository;
        public HallService(ILogger<HallService> logger, IHallRepository hallRepository)
        {
            _logger = logger;
            _hallRepository = hallRepository;
        }

        public List<Hall> GetHalls()
        {
            return _hallRepository.GetHalls();
        }
    }
}
