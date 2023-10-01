using BusinessLayer.DapperRepository;
using Dapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace DataAccessLayer.Dapper
{
    public class NewsDA : GenericRepositoryDap<News>, INewDA
    {
        private readonly string? _connectionString;
        public NewsDA(NEUContext context) : base(context)
        {
            _connectionString = context?.Database?.GetConnectionString();
        }

        public async Task<bool> CreateNewsAsync(News news)
        {
            string query = "INSERT INTO News(New_Id,Title,PublishDate,CategoryId,Source,FilesId) VALUES("
                 + "@newId,@publishdate,@categoryid,@source,@filesid);";

            var parameters = new
            {
                newId = news.New_Id,
                publishdate = news.PublishDate,
                categoryid = news.CategoryId,
                source = news.Source,
                filesid = news.FilesId
            };

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var ExecuteVal = await connection.ExecuteAsync(query, parameters);
                return ExecuteVal > 0;
            }
        }

        public async Task<bool> DeleteNewsById(int id)
        {
            string query = "DELETE FROM News WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var affectedRows = await connection.ExecuteAsync(query, parameters);
                return affectedRows > 0;
            }
        }

        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {
            string query = "Select * From News";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                IEnumerable<News> news = await connection.QueryAsync<News>(query);
                return news;
            }
        }

        public async Task<News> GetNewsByIdAsync(int id)
        {
            string query = "Select * From News where Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<News>(query, parameters);
            }
        }

        public async Task<bool> UpdateNews(News news)
        {


            string query = "UPDATE News SET New_Id = @newid,Title =@title,PublishDate = @publishdate," +
               "CategoryId = @categoryid,Source = @source,FilesId = @filesid";
            var parameters = new
            {
                newId = news.New_Id,
                publishdate = news.PublishDate,
                categoryid = news.CategoryId,
                source = news.Source,
                filesid = news.FilesId
            };
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var ExecuteVal = await connection.ExecuteAsync(query, parameters);
                return ExecuteVal > 0;
            }
        }
    }
}
