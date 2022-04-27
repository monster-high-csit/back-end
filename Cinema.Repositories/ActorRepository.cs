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

        public int CreateActor(Actor actor)
        {
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                //Добавить querry
                var query = "INSERT INTO [dbo].[A] " +
                            "([GenreID], " +
                            "[StudioID], " +
                            "[FilmmakerID], " +
                            "[Name], " +
                            "[AgeLimit], " +
                            "[Description], " +
                            "[ShortDescription], " +
                            "[Rating], " +
                            "[Duration]) " +
                            "VALUES " +
                            "(@GenreID, " +
                            "@StudioID, " +
                            "@FilmmakerID, " +
                            "@Name, " +
                            "@AgeLimit, " +
                            "@Description, " +
                            "@ShortDescription, " +
                            "@Rating," +
                            "@Duration)";
                return db.Query(query, actor).Count();
            };
        }

        public int DeleteActor(int id)
        {
            using (SqlConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                var command = new SqlCommand($"DELETE FROM dbo.Actors WHERE ActorID = {id}", db);
                db.Open();
                return (int)command.ExecuteNonQuery();
            }
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

        public List<Actor> GetActors()
        {
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                var query = "SELECT * FROM dbo.Actors";
                return db.Query<Actor>(query).ToList();
            }
        }
    }
}
