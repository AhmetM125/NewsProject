using BusinessLayer.DapperRepository;
using Dapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace DataAccessLayer.Dapper
{
    public class PermissionDA : GenericRepositoryDap<Permission>, IPermissionDA
    {
        private readonly string? _connectionString;
        public PermissionDA(NEUContext context) : base(context)
        {
            _connectionString = context?.Database?.GetConnectionString();
        }

        public Task<bool> CreatePermissionAsync(Permission permission)
        {
            throw new NotImplementedException();
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

        public Task<bool> UpdatePermission(Permission permission)
        {
            throw new NotImplementedException();
        }
    }
}
