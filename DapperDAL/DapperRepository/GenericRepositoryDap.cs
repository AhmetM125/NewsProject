using Dapper;
using Dapper.Contrib.Extensions;
using DataAccessLayer.Context;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Reflection;

namespace BusinessLayer.DapperRepository
{
    public class GenericRepositoryDap<T> : IRepositoryDAP<T> where T : class
    {
        private readonly string _dbConnection;

        public GenericRepositoryDap(NEUContext context)
        {
            _dbConnection = context?.Database?.GetConnectionString();
        }
        public Queue<string> GetColumnNames()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            Queue<string> values = new Queue<string>();
            foreach (PropertyInfo property in properties)
            {
                values.Enqueue(property.Name);
            }
            return values;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            string value = typeof(T).Name;
            if (value.Last() != 's')
                value = value + 's';
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                return await connection.QueryAsync<T>("SELECT * FROM " + value);
            }
        }
        public async Task<bool> Insert(T t)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(_dbConnection))
                {
                    var inserted = await connection.InsertAsync<T>(t);

                        return true;
                }
            }
            catch (Exception)
            {
                return
                    false;
            }


            /*// insert into (tableName) values 
            string query = $"Insert Into {typeof(T).Name}  (";
            Queue<string> values = GetColumnNames();

            for (int i = 0; i < values.Count; i++)
            {
                query += values.Dequeue() + ",";
            }
            query.Remove(query.Length - 1);
            query += ") VALUES(";
            query += Strquery + ");";*/

        }
        public async Task<T> GetById(Guid id)
        {

            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                return await connection.GetAsync<T>(id);
              //  return await connection.QueryFirstOrDefaultAsync<T>("SELECT * FROM " + typeof(T).Name + " WHERE @val = @Id", new { Id = id, val = _value });
            }

        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dbConnection))
                {
                    var entity = await connection.GetAsync<T>(id);

                    if(entity == null)
                        return false;

                    return await connection.DeleteAsync<T>(entity);
                }

            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}

/*public IEnumerable<T> GetAll()
{

    string query = "SELECT * FROM @Value";
    string connection2 = "server=LPTNET052\\SQLEXPRESS;database=NewsDb;integrated security=true;Encrypt=false";
    DynamicParameters paramaters = new DynamicParameters();
    paramaters.Add("@value", obj);

    using (SqlConnection connection = new SqlConnection(connection2))
    {
        var ListOfValue = connection.Query<T>(query, paramaters);
        return ListOfValue;
    }

}*/