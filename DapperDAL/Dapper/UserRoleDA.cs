using BusinessLayer.DapperRepository;
using Dapper;
using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer.Dapper
{
    public class UserRoleDA : GenericRepositoryDap<UserRole>, IUserRoleDA
    {
        private readonly string? connectionString;
        private readonly IConfiguration configuration;
        public UserRoleDA()
        {
            //  connectionString = context.Database.GetConnectionString();
            var test = configuration.GetConnectionString("DefaultConnectionString");
        }

        public async Task<bool> CreateUserRoleAsync(UserRole UserRole)
        {
            string query = "INSERT INTO UserRole(UserId,RoleId) VALUES(@userid,@roleid);";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@userid", UserRole.UserId);
            dynamicParameters.Add("@roleid", UserRole.RoleId);
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var result = await sqlConnection.ExecuteAsync(query, dynamicParameters);
                return result > 0;
            }
        }

        public async Task<bool> DeleteUserRoleById(Guid Uid, int RoleId)
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

        public async Task<UserRole> GetUserRoleByIdAsync(Guid Uid, int RoleId)
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

        public async Task<bool> UpdateUserRole(UserRole UserRole)
        {
            string query = "UPDATE UserRole SET UserId = @userid , RoleId = @roleid";
            var parameters = new DynamicParameters();
            parameters.Add("@userid", UserRole.UserId);
            parameters.Add("@roleid", UserRole.RoleId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var result = await connection.ExecuteAsync(query, parameters);
                return result > 0;
            }
        }
    }
}
