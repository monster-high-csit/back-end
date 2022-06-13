using Cinema.Entities;
using Cinema.IRepositories;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Cinema.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly DbOptions _dbOptions;

        public UserRepository(ILogger<UserRepository> logger, DbOptions dbOptions)
        {
            _logger = logger;
            _dbOptions = dbOptions;
        }

        public User GetUser(string login)
        {
            var query = "SELECT * FROM dbo.Users WHERE Email = @email;";
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                return db.Query<User>(query, new { email = login }).ToList().First();
            }
        }

        public List<User> GetUsers()
        {
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                var query = "SELECT * FROM dbo.Users";
                return db.Query<User>(query).ToList();
            }
        }

        public bool LoginUser(User user)
        {
            var query = "SELECT * FROM dbo.Users WHERE Email = @email AND Password = @password;";
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                try
                {
                    var res = db.Query<User>(query, new { email = user.Email, password = user.Password }).ToList().First();
                    return true;
                }
                catch (Exception ex)//Леван поправь, я не помню какое исключение будет если ничё не вернётся
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
