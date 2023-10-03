using BusinessLayer.DapperRepository;
using Dapper;
using DataAccessLayer.Abstract;
using EntityLayer;
using System.Data.SqlClient;

namespace DataAccessLayer.Dapper
{
    public class PermissionDA : GenericRepositoryDap<Permission>, IPermissionDA
    {
        private readonly string? _connectionString;
        public PermissionDA( ) : base()
        {
         //   _connectionString = context?.Database?.GetConnectionString();
        }

        public async Task<bool> CreatePermissionAsync(Permission permission)
        {
            string query = "INSERT INTO Permissions(Title) VALUES("
               + "@title);";

            var parameters = new
            {
                title = permission.Title
            };

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var ExecuteVal = await connection.ExecuteAsync(query, parameters);
                return ExecuteVal > 0;
            }
        }

        public async Task<bool> DeletePermissionsById(int id)
        {
            string query = "DELETE FROM Permissions WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var affectedRows = await connection.ExecuteAsync(query, parameters);
                return affectedRows > 0;
            }

        }

        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            string query = "Select * From Permissions";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                IEnumerable<Permission> permission = await connection.QueryAsync<Permission>(query);
                return permission;
            }
        }

        public async Task<Permission> GetPermissionsByIdAsync(int id)
        {
            string query = "Select * From News where Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Permission>(query, parameters);
            }
        }

        public async Task<bool> UpdatePermission(Permission permission)
        {
            string query = "Update Permissions SET Title = @title";
            var parameters = new DynamicParameters();
            parameters.Add("@title", permission.Title);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(query, parameters);
                return result > 0;
            }
        }
    }
}
