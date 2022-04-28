using Cinema.Entities;
using Cinema.IRepositories;
using Dapper;
using Microsoft.Extensions.Logging;
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
        public List<User> GetUsers()
        {
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                var query = "SELECT * FROM dbo.Users";
                return db.Query<User>(query).ToList();
            }
        }
    }
}
