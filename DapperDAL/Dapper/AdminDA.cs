using BusinessLayer.DapperRepository;
using Dapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace DataAccessLayer.Dapper
{
    public class AdminDA : GenericRepositoryDap<Admin>, IAdminDA
    {
        private readonly string? connectionString;
        public AdminDA(NEUContext context) : base(context)
        {
            connectionString = context.Database.GetConnectionString();
        }
        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            string query = "Select * From Admins";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                IEnumerable<Admin> admins = await connection.QueryAsync<Admin>(query);
                return admins;

            }
        }
        public async Task<Admin> GetAdminById(Guid id)
        {
            string query = "Select * From Admins where User_Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Admin>(query, parameters);
            }
        }
        public async Task<bool> DeleteAdmin(Guid id)
        {
            string query = "DELETE FROM Admins WHERE User_Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var affectedRows = await connection.ExecuteAsync(query, parameters);
                return affectedRows > 0;
            }

        }
        public async Task<bool> InsertAdmin(Admin admin)
        {
            string query = "INSERT INTO Admins(User_Id,Name,Surname,Username,Password) VALUES("
                + "@id,@name,@surname,@username,@password);";

            var parameters = new
            {
                id = admin.User_Id,
                name = admin.Name,
                surname = admin.Surname,
                username = admin.Username,
                password = admin.Password
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var ExecuteVal = await connection.ExecuteAsync(query, parameters);
                return ExecuteVal > 0;
            }

        }
        public async Task<bool> UpdateAdmin(Admin admin)
        {
            string query = @"UPDATE Admins SET Name = @name,Surname =@surname,Username = @username, password = @password";
            var parameters = new DynamicParameters();
            parameters.Add("@name", admin.Name);
            parameters.Add("@surname", admin.Surname);
            parameters.Add("@username", admin.Username);
            parameters.Add("@password", admin.Password);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var ExecuteVal = await connection.ExecuteAsync(query, parameters);
                return ExecuteVal > 0;
            }
        }


    }
}
