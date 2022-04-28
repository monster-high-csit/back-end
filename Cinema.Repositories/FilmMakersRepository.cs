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
    public class FilmMakersRepository : IFilmMakersRepository
    {
        private readonly ILogger<FilmMakersRepository> _logger;
        private readonly DbOptions _dbOptions;

        public FilmMakersRepository(ILogger<FilmMakersRepository> logger, DbOptions dbOptions)
        {
            _logger = logger;
            _dbOptions = dbOptions;
        }

        public int Add(FilmMaker filmMaker)
        {
            var query = "INSERT INTO [dbo].FilmMakers (Name, Surname) VALUES (@name, @surname); SELECT SCOPE_IDENTITY();";
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                return (int)(db.Query<decimal>(query, filmMaker).First());
            }
        }

        public FilmMaker GetFilmMakerByID(int id)
        {
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                var query = $"SELECT * FROM [dbo].Filmmakers WHERE FilmmakerID = {id}";
                return db.Query<FilmMaker>(query).First();
            }
        }

        public List<FilmMaker> GetFilmMakers()
        {
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                var query = "SELECT * FROM [dbo].Filmmakers";
                return db.Query<FilmMaker>(query).ToList();
            }
        }

        public int GetFilmStudioIDByName(string name, string surname)
        {
            var query = "SELECT FilmMakerID FROM [dbo].FilmMakers WHERE Name = @name AND Surname = @surname;";
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                return db.Query<int>(query, new { name = name, surname = surname}).ToList().First();
            }
        }
    }
}
