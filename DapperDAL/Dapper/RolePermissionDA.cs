using BusinessLayer.DapperRepository;
using Dapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace DataAccessLayer.Dapper
{
    public class RolePermissionDA : GenericRepositoryDap<RolePermission>, IRolePermissionDa
    {
        private readonly string? connectionString;
        public RolePermissionDA(NEUContext context) : base(context)
        {
            connectionString = context.Database.GetConnectionString();
        }

        public async Task<bool> CreateRolePermissionAsync(RolePermission RolePermission)
        {
            string query = "INSERT INTO RolePermissions(RoleId,PermissionId) VALUES(@roleid,@permissionid);";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@roleid", RolePermission.RoleId);
            dynamicParameters.Add("@permissionid", RolePermission.PermissionId);
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var result = await sqlConnection.ExecuteAsync(query, dynamicParameters);
                return result > 0;
            }

        }

        public async Task<bool> DeleteRolePermissionById(int RoleId, int PermissionId)
        {
            string query = "DELETE FROM RolePermissions where RoleId = @roleid and PermissionId = @permissionid";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@roleid", RoleId);
            dynamicParameters.Add("@permissionid", PermissionId);
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var result = await sqlConnection.ExecuteAsync(query, dynamicParameters);
                return result > 0;
            }
        }

        public async Task<IEnumerable<RolePermission>> GetAllRolePermissionsAsync()
        {
            string query = "Select * From RolePermissions";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                IEnumerable<RolePermission> rolePermissions = await connection.QueryAsync<RolePermission>(query);
                return rolePermissions;

            }
        }

        public async Task<RolePermission> GetRolePermissionByIdAsync(int RoleId, int PermissionId)
        {
            string query = "SELECT * FROM RolePermissions where RoleId = @roleid and PermissionId = @permissionid";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@roleid", RoleId);
            dynamicParameters.Add("@permissionid", PermissionId);
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                return await sqlConnection.QueryFirstOrDefaultAsync<RolePermission>(query, dynamicParameters);
            }
        }

        public async Task<bool> UpdateRolePermission(RolePermission RolePermission)
        {
            string query = "UPDATE RolePermissions set RoleId = @roleid , PermissionId = @permissionid";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@roleid", RolePermission.RoleId);
            dynamicParameters.Add("@permissionid", RolePermission.PermissionId);
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var result = await sqlConnection.ExecuteAsync(query, dynamicParameters);
                return result > 0;
            }
        }
    }
}
