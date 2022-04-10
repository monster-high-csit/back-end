using Cinema.Entities;
using Cinema.IRepositories;
using Cinema.IServices;
using Microsoft.Extensions.Logging;

namespace Cinema.Services
{
    public class ActorService : IActorService
    {
        private readonly ILogger<ActorService> _logger;
        private readonly IActorRepository _actorRepository;
        public ActorService(ILogger<ActorService> logger, IActorRepository actorRepository)
        {
            _logger = logger;
            _actorRepository = actorRepository;
        }
        public Actor GetActor(int id)
        {
            return _actorRepository.GetActor(id);
        }
    }
}
