using Cinema.Dto;
using Cinema.Entities;
using Cinema.IRepositories;
using Dapper;
using Microsoft.Extensions.Logging;
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

        public int DeleteFilm(int id)
        {
            using (SqlConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                var command = new SqlCommand($"DELETE FROM dbo.Films WHERE FilmID = {id}", db);
                db.Open();
                return (int)command.ExecuteNonQuery();
            }
        }

        public FilmDto GetBook(int id)
        {
            using (IDbConnection db = new SqlConnection(_dbOptions.ConnectionString))
            {
                var param = new DynamicParameters();
                param.Add("FilmID", id);
                var query = "SELECT f.FilmID,"+
                            "f.Name, " +
                            "(SELECT g.Name FROM dbo.Genres AS g WHERE GenreID = f.GenreID) AS Genre, " +
                            "(SELECT fs.Name FROM dbo.FilmStudios AS fs WHERE StudioID = f.StudioID) AS FilmStudio, " +
                            "(SELECT CONCAT(fm.Name, ' ', fm.Surname) FROM dbo.Filmmakers AS fm WHERE FilmmakerID = f.FilmmakerID) AS Filmmaker, " +
                            "f.AgeLimit, " +
                            "f.Description, "+
                            "f.ShortDescription, "+
                            "f.Rating, "+
                            "f.Duration "+
                            "FROM Films AS f WHERE FilmID = @FilmID";
                return db.Query<FilmDto>(query, param).First();
            }
        }
    }
}
