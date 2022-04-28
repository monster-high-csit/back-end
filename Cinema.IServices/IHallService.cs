using Cinema.Entities;
using System.Collections.Generic;

namespace Cinema.IServices
{
    public interface IHallService
    {
        List<Hall> GetHalls();
    }
}
