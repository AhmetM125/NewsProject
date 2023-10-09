using BusinessLayer.DapperRepository;
using Dapper;
using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Web.Http.Results;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer.Dapper
{
    public class NewsDA : GenericRepositoryDap<New>, INewDA
    {
        private readonly string? _connectionString; 
        private readonly IConfiguration _configuration;
        public NewsDA(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        public async Task<bool> CreateNewsAsync(New news)
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

        public async Task<IEnumerable<New>> GetAllNewsAsync()
        {
            string query = "Select * From News";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                IEnumerable<New> news = await connection.QueryAsync<New>(query);
                return news;
            }
        }

        public async Task<IEnumerable<New>> GetNewsByCategoryId(string categoryId)
        {
            string query = $"Select * from News where CategoryId = @categoryid";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryid", categoryId);
            using(SqlConnection  connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<New>(query, parameters);
            }

        }

        public async Task<New> GetNewsByIdAsync(int id)
        {
            string query = "Select * From News where Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<New>(query, parameters);
            }
        }

        public async Task<bool> UpdateNews(New news)
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
