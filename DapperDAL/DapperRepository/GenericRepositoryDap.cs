using Dapper;
using Dapper.Contrib.Extensions;
using DataAccessLayer.Context;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Data;
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

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll(string query)
        {
            using(SqlConnection connection = new SqlConnection(_dbConnection))
            {
                return await connection.QueryAsync<T>(query);
            }
        }

        public Task<T> GetById(int id,string query)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

