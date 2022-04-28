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
    public class GenreRepository : IGenreRepository
    {
        private readonly ILogger<GenreRepository> _logger;
        private readonly DbOptions _dbOptions;

        public GenreRepository(ILogger<GenreRepository> logger, DbOptions dbOptions)
        {
            _logger = logger;
            _dbOptions = dbOptions;
        }

        public int Add(Genre genre)
        {
            var query = "INSERT INTO [dbo].Genres (Name) VALUES (@name); SELECT SCOPE_IDENTITY();";
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                return (int)(db.Query<decimal>(query, genre).First());
            }
        }

        public Genre GetGenreByID(int id)
        {
            var query = $"SELECT * FROM [dbo].Genres WHERE GenreID = {id}";
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                return db.Query<Genre>(query).ToList().First();
            }
        }

        public int GetGenreIDByName(string name)
        {
            var query = "SELECT GenreID FROM Genres WHERE Name = @name;";
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                return db.Query<int>(query, name).ToList().First();
            }
        }

        public List<Genre> GetGenres()
        {
            var query = $"SELECT * FROM [dbo].Genres";
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                return db.Query<Genre>(query).ToList();
            }
        }
    }
}
