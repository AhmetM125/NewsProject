 using Dapper;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace BusinessLayer.DapperRepository
{
    public class GenericRepositoryDap<T> : IRepositoryDAP<T> where T : class
    {
        private readonly string? _dbConnection;

        public GenericRepositoryDap(NEUContext context)
        {
            _dbConnection = context?.Database?.GetConnectionString();
        }

      


      
    }
}

