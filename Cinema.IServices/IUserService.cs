using Cinema.Entities;
using System.Collections.Generic;

namespace Cinema.IServices
{
    public interface IUserService
    {
        List<User> GetUsers();
    }
}
