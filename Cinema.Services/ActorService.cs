using Cinema.Entities;
using Cinema.IRepositories;
using Cinema.IServices;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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

        public int CreateActor(Actor actor)
        {
            return _actorRepository.CreateActor(actor);
        }

        public Actor GetActor(int id)
        {
            return _actorRepository.GetActor(id);
        }

        public List<Actor> GetActorByFilmIDs(IEnumerable<int> IDs)
        {
            throw new System.NotImplementedException();
        }

        public List<Actor> GetActors()
        {
            return _actorRepository.GetActors();
        }
    }
}
