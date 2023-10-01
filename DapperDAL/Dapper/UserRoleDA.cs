using BusinessLayer.DapperRepository;
using Dapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace DataAccessLayer.Dapper
{
    public class UserRoleDA : GenericRepositoryDap<UserRole>, IUserRoleDA
    {
        private readonly string? connectionString;

        public UserRoleDA(NEUContext context) : base(context)
        {
            connectionString = context.Database.GetConnectionString();
        }

        public Task<bool> CreateUserRoleAsync(UserRole UserRole)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUserRoleById(Guid Uid,int RoleId)
        {
            string query = "DELETE FROM UserRole WHERE User_Id = @Id and RoleId = @roleid";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Uid);
            parameters.Add("@roleid", RoleId);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var affectedRows = await connection.ExecuteAsync(query, parameters);
                return affectedRows > 0;
            }
        }

        public async Task<IEnumerable<UserRole>> GetAllUserRolesAsync()
        {
            string query = "Select * From UserRole";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                IEnumerable<UserRole> userRoles = await connection.QueryAsync<UserRole>(query);
                return userRoles;

            }
        }

        public async Task<UserRole> GetUserRoleByIdAsync(Guid Uid,int RoleId)
        {
            string query = "Select * From UserRole where User_Id = @Id and RoleId = @RoleId";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Uid);
            parameters.Add("@RoleId", RoleId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<UserRole>(query, parameters);
            }
        }

        public Task<bool> UpdateUserRole(UserRole UserRole)
        {
            throw new NotImplementedException();
        }
    }
}
