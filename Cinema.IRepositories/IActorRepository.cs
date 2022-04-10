using Cinema.Entities;
using System.Collections.Generic;

namespace Cinema.IRepositories
{
    public interface IActorRepository
    {
        Actor GetActor(int id);
        List<Actor> GetActorByFilmIDs(IEnumerable<int> IDs);
        int Add(Actor actor);
    }
}
