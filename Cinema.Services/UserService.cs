using Cinema.Entities;
using Cinema.IRepositories;
using Cinema.IServices;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Cinema.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        public UserService(ILogger<UserService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public User GetUser(string login)
        {
            return _userRepository.GetUser(login);
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public bool LoginUser(User user)
        {
            return _userRepository.LoginUser(user);
        }
    }
}
