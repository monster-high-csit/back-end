using Cinema.Dto;
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
    public class FilmRepository : IFilmRepository
    {
        private readonly ILogger<FilmRepository> _logger;
        private readonly DbOptions _dbOptions;

        public FilmRepository(ILogger<FilmRepository> logger, DbOptions dbOptions)
        {
            _logger = logger;
            _dbOptions = dbOptions;
        }

        public void CreateFilm(FilmDto filmDto)
        {
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                var query = "INSERT INTO [dbo].[Films] " +
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
                db.Query(query, filmDto);
            }
        }

        public int DeleteFilm(int id)
        {
            using (SqlConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                var command = new SqlCommand($"DELETE FROM dbo.Films WHERE FilmID = {id}", db);
                db.Open();
                return (int)command.ExecuteNonQuery();
            }
        }

        public FilmDto GetFilm(int id)
        {
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                var param = new DynamicParameters();
                param.Add("FilmID", id);
                var query = "SELECT f.FilmID, "+
                            "f.Name, " +
                            "f.GenreID, " +
                            "f.StudioID AS FilmStudioID, " +
                            "f.FilmmakerID, " +
                            "f.AgeLimit, " +
                            "f.Description, "+
                            "f.ShortDescription, "+
                            "f.Rating, "+
                            "f.Duration "+
                            "FROM Films AS f WHERE FilmID = @FilmID";
                return db.Query<FilmDto>(query, param).First();
            }
        }

        public List<FilmDto> GetFilms()
        {
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                var query = "SELECT f.FilmID, " +
                            "f.Name, " +
                            "f.GenreID, " +
                            "f.StudioID AS FilmStudioID, " +
                            "f.FilmmakerID, " +
                            "f.AgeLimit, " +
                            "f.Description, " +
                            "f.ShortDescription, " +
                            "f.Rating, " +
                            "f.Duration " +
                            "FROM Films AS f";
                return db.Query<FilmDto>(query).ToList();
            }
        }
    }
}
