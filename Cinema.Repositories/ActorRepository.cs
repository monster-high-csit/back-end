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
    public class ActorRepository : IActorRepository
    {
        private readonly ILogger<ActorRepository> _logger;
        private readonly DbOptions _dbOptions;

        public ActorRepository(ILogger<ActorRepository> logger, DbOptions dbOptions)
        {
            _logger = logger;
            _dbOptions = dbOptions;
        }
        public Actor GetActor(int id)
        {
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                var param = new DynamicParameters();
                param.Add("ActorID", id);
                var query = "SELECT * FROM dbo.Actors WHERE ActorID = @ActorID";
                return db.Query<Actor>(query, param).First();
            }
        }
        public List<Actor> GetActorByFilmIDs(IEnumerable<int> IDs)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EntityID");
            foreach(var id in IDs)
            {
                dt.Rows.Add(id);
            }
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                return db.Query<Actor>("GetActorByFilmIDs",
                        new { IDs = dt.AsTableValuedParameter("dtIntEntity") },
                        commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
