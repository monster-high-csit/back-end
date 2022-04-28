using Cinema.Entities;
using System.Collections.Generic;

namespace Cinema.IRepositories
{
    public interface IHallRepository
    {
        List<Hall> GetHalls();
    }
}
