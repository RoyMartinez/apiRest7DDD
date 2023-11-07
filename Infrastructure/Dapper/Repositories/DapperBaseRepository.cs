using Dapper;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Dapper.Repositories
{
    public class DapperBaseRepository<TEntity> : IDapperBaseRepository<TEntity> where TEntity : class
    {
        private readonly string _connectionString;
        public DapperBaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")??"";
        }

        public async Task<IEnumerable<TEntity>> query(string query)
        {

            query = "set nocount on; \n" + query;

            using var connection = new SqlConnection(_connectionString);

            var entities = await connection.QueryAsync<TEntity>(query);

            return await Task.FromResult(entities);
        }

        public async Task<int> command(string command)
        {
            using var connection = new SqlConnection(_connectionString);

            var affectedRows = await connection.ExecuteAsync(command);

            return await Task.FromResult(affectedRows);
        }
    }
}
