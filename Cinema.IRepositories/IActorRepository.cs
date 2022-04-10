using Cinema.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Cinema.IRepositories
{
    public interface IActorRepository
    {
        Actor GetActor(int id);
        List<Actor> GetActorByFilmIDs(IEnumerable<int> IDs);
    }
}
