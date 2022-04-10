using Cinema.Entities;
using Cinema.IRepositories;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Cinema.Repositories
{
    public class FilmStudioRepository : IFilmStudioRepository
    {
        private readonly ILogger<FilmStudioRepository> _logger;
        private readonly DbOptions _dbOptions;

        public FilmStudioRepository(ILogger<FilmStudioRepository> logger, DbOptions dbOptions)
        {
            _logger = logger;
            _dbOptions = dbOptions;
        }

        public int Add(FilmStudio filmStudio)
        {
            var query = "INSERT INTO [dbo].FilmStudios (Name) VALUES (@name); SELECT SCOPE_IDENTITY();";
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                return (int)(db.Query<decimal>(query, filmStudio).First());
            }
        }

        public FilmStudio GetFilmStudioByID(int id)
        {
            var query = $"SELECT * FROM [dbo].FilmStudios WHERE StudioID = {id}";
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                return db.Query<FilmStudio>(query).ToList().First();
            }
        }

        public int GetFilmStudioIDByName(string name)
        {
            var query = "SELECT StudioID FROM [dbo].FilmStudios WHERE Name = @name;";
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                return db.Query<int>(query, name).ToList().First();
            }
        }
    }
}
