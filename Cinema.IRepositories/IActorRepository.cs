using Cinema.Entities;
using System.Collections.Generic;

namespace Cinema.IRepositories
{
    public interface IActorRepository
    {
        Actor GetActor(int id);
        List<Actor> GetActorByFilmIDs(IEnumerable<int> IDs);
        int CreateActor(Actor actor);
        List<Actor> GetActors();
    }
}
