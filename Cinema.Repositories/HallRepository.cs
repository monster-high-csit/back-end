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
    public class HallRepository : IHallRepository
    {
        private readonly ILogger<HallRepository> _logger;
        private readonly DbOptions _dbOptions;

        public HallRepository(ILogger<HallRepository> logger, DbOptions dbOptions)
        {
            _logger = logger;
            _dbOptions = dbOptions;
        }

        public List<Hall> GetHalls()
        {
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                var query = "SELECT * FROM dbo.Halls";
                return db.Query<Hall>(query).ToList();
            }
        }
    }
}
