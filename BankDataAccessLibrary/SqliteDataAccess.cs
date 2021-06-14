using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using BankDataAccessLibrary.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace BankDataAccessLibrary
{
    public class SqliteDataAccess : ISqliteDataAccess
    {
        private readonly IConfiguration _configuration;

        public string ConnectionStringName { get; set; } = "Default";

        public SqliteDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            using (IDbConnection cnn = new SQLiteConnection(_configuration.GetConnectionString(ConnectionStringName)))
            {
                var output = await cnn.QueryAsync<T>(sql, parameters);

                return output.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            using (IDbConnection cnn = new SQLiteConnection(_configuration.GetConnectionString(ConnectionStringName)))
            {
                  await cnn.ExecuteAsync(sql, parameters);
            }

        }
    }

}
