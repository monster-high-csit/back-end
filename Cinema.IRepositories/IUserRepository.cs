using Cinema.Entities;
using System.Collections.Generic;

namespace Cinema.IRepositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        bool LoginUser(User user);
        User GetUser(string login);
    }
}
