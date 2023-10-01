using BusinessLayer.DapperRepository;
using Dapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace DataAccessLayer.Dapper
{
    public class RoleDA : GenericRepositoryDap<Role>, IRoleDA
    {
        private readonly string? connectionString;

        public RoleDA(NEUContext context) : base(context)
        {
            connectionString = context.Database.GetConnectionString();
        }

        public async Task<bool> CreateRoleAsync(Role role)
        {
            string query = "INSERT INTO Roles(Title) VALUES (@title);";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@title", role.Title);
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                var result = await connection.ExecuteAsync(query,parameters);
                return result > 0;
            }
        }

        public async Task<bool> DeleteRoleById(int id)
        {
            string query = "DELETE FROM Roles WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var affectedRows = await connection.ExecuteAsync(query, parameters);
                return affectedRows > 0;
            }

        }

        public async Task<IEnumerable<Role>> GetAllRoleAsync()
        {
            string query = "Select * From Roles";
            using (SqlConnection connection = new SqlConnection())
            {
                IEnumerable<Role> roles = await connection.QueryAsync<Role>(query);
                return roles;

            }
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            string query = "Select * From Roles where Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Role>(query, parameters);
            }
        }

        public async Task<bool> UpdateRole(Role role)
        {
            string query = "UPDATE Roles SET Title = @title;";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@title", role.Title);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var result = await connection.ExecuteAsync(query, parameters);
                return result > 0;
            }
        }
    }
}
