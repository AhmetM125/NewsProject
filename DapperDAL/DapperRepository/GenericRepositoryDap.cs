using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer.DapperRepository
{
    public class GenericRepositoryDap<T> : IRepositoryDAP<T> where T : class
    {
        private readonly string? _dbConnection = "server=LPTNET052\\SQLEXPRESS;database=NewsDb;integrated security=true;Encrypt=false";
        /*private readonly string? _PrimaryKey;
        private readonly string? _tableName;
        private readonly TableAttribute? _tableAttribute;*/
        public GenericRepositoryDap()
        {
           // _dbConnection = context?.Database?.GetConnectionString(); **


           /* _PrimaryKey = typeof(T).GetProperties().FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(KeyAttribute)))?.Name;//primary key 


            _tableAttribute = (TableAttribute?)Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute)); //If custom table name exist it will be use 
            _tableName = (_tableAttribute is null) ? typeof(T).Name : _tableAttribute.Name;
     */   }

        /*public async Task<int> Delete(string id)
        {
            *//*string query = $"Delete {_tableName} WHERE {_PrimaryKey} = {id}";
            using (SqlConnection connection = new(_dbConnection))
            {
                return await connection.ExecuteAsync(query);
            }*//*

            using(IDbConnection connection = new SqlConnection(_dbConnection))
            {
                return await connection.DeleteAsync(id);
            }
        }*/

        public async Task<bool> DeleteByEntity(T t)
        {

            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
               return await connection.DeleteAsync(t);
            }


        }


        public async Task<IEnumerable<T>> GetAll()
        {
            using(IDbConnection connection = new SqlConnection(_dbConnection))
            {
                return await connection.GetAllAsync<T>();
            }
            /*string query = $"SELECT * FROM {_tableName}";

            using (SqlConnection connection = new(_dbConnection))
            {
                return await connection.QueryAsync<T>(query);
            }*/
        }



        public async Task<T?> GetById(string id)
        {
            /*string query = $"Select * FROM {_tableName} where {_PrimaryKey} = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);*/
            using(IDbConnection connection = new SqlConnection(_dbConnection))
            {
                return await connection.GetAsync<T>(id);
            }
          /*  using (SqlConnection connection = new(_dbConnection))
            {
                return await connection.QueryFirstAsync<T>(query, parameters);
            }*/

        }

        public async Task<int> Insert(T entity)
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                return await connection.InsertAsync<T>(entity);
            }
        }

        public async Task<bool> Update(T entity)
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                return await connection.UpdateAsync(entity);
            }
        }
    }
}

