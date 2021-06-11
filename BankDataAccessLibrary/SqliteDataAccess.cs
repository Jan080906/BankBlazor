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
    public class SqliteDataAccess
    {
        private readonly IConfiguration _configuration;

        public string ConnectionStringName { get; set; } = "Default";

        public SqliteDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static List<CustomerAccountModel> LoadAccount()
        {
            using (IDbConnection cnn = new SQLiteConnection(@"DataSource=./Bank.db;"))
            {
                var output = cnn.Query<CustomerAccountModel>("select * from CustomerAccount", new DynamicParameters());

                return output.ToList();
            }
        }

        public static void SaveAccount(CustomerAccountModel customerAccount)
        {
            using (IDbConnection cnn = new SQLiteConnection(@"DataSource=./Bank.db;"))
            {
                    cnn.Execute("insert into CustomerAccount (Number, Name, Address, IBAN) " +
                        "values (@Number, @Name, @Address, @IBAN)", customerAccount);

            }

        }

        // DataSource=.\Back.db;Version=3

        //private static string LoadConnectionString()

        //public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        //{
        //    string connectionString = _configuration.GetConnectionString(ConnectionStringName);

        //    using (IDbConnection connection = new SqlConnection(connectionString))
        //    {
        //        var data = await connection.QueryAsync<T>(sql, parameters);

        //        return data.ToList();
        //    }
        //}

        //public async Task SaveData<T>(string sql, T parameters)
        //{
        //    string connectionString = _configuration.GetConnectionString(ConnectionStringName);

        //    using (IDbConnection connection = new SqlConnection(connectionString))
        //    {
        //        var data = await connection.ExecuteAsync(sql, parameters);
        //    }
        //}
    }

}
