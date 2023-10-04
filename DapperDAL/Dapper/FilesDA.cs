using BusinessLayer.DapperRepository;
using Dapper;
using DataAccessLayer.Abstract;
using EntityLayer;
using System.Data.SqlClient;

namespace DataAccessLayer.Dapper
{
    public class FilesDA : GenericRepositoryDap<EntityLayer.File>, IFilesDA
    {
        private readonly string _connectionString;
        public FilesDA() : base()
        {
           // _connectionString = context.Database.GetConnectionString();
        }

        public async Task<bool> DeleteFile(Guid id)
        {
            string query = "DELETE Files WHERE Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(query, parameters);
                return result > 0;
            }

        }

        public async Task<IEnumerable<EntityLayer.File>> GetAllFiles()
        {
            string query = "SELECT * FROM Files";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<EntityLayer.File>(query);
            }
        }

        public async Task<EntityLayer.File> GetFileById(Guid id)
        {
            string query = "Select * From Files where Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<EntityLayer.File>(query, parameters);
            }
        }

        public async Task<bool> InsertFile(EntityLayer.File file)
        {
            string query = "INSERT INTO Files(Id,FileName,ContentType,Extension,Content,Size) VALUES(@id,@fname,@contenttype,@extension,@content,@size);";
            var parameters = new DynamicParameters();
            parameters.Add("@id", file.Id);
            parameters.Add("@fname", file.FileName);
            parameters.Add("@contenttype", file.ContentType);
            parameters.Add("@extension", file.Extention);
            parameters.Add("@content", file.Content);
            parameters.Add("@size", file.Size);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(query, parameters);
                return result > 0;
            }
        }

        public async Task<bool> UpdateFile(EntityLayer.File file)
        {
            string query = "UPDATE Files SET FileName = @fname,Id=@id,ContentType = @contenttype," +
                "Extension = @extension,Content = @content,Size = @size";
            var parameters = new DynamicParameters();
            parameters.Add("@id", file.Id);
            parameters.Add("@fname", file.FileName);
            parameters.Add("@contenttype", file.ContentType);
            parameters.Add("@extension", file.Extention);
            parameters.Add("@content", file.Content);
            parameters.Add("@size", file.Size);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(query, parameters);
                return result > 0;
            }
        }
    }
}
