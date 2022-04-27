using Cinema.Entities;
using System.Collections.Generic;

namespace Cinema.IServices
{
    public interface IActorService
    {
        Actor GetActor(int id);
        List<Actor> GetActorByFilmIDs(IEnumerable<int> IDs);
        List<Actor> GetActors();
        int CreateActor(Actor actor);
        int DeleteActor(int id);
    }
}
