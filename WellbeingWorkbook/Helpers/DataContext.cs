using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace WellbeingWorkbook.Helpers
{
    public class DataContext
    {
        private readonly DbSettings _dbSettings;

        public DataContext(IOptions<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = $"Server={_dbSettings.Server}; Database={_dbSettings.Database}; User Id={_dbSettings.UserId}; Password={_dbSettings.Password};";
            return new SqlConnection(connectionString);
        }

        public async Task Init()
        {
            await _initDatabase();
            await _initTables();
        }

        private async Task _initDatabase()
        {
            // create database if it doesn't exist
            var connectionString = $"Server={_dbSettings.Server}; Database=master; User Id={_dbSettings.UserId}; Password={_dbSettings.Password};";
            using var connection = new SqlConnection(connectionString);
            var sql = $"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '{_dbSettings.Database}') CREATE DATABASE [{_dbSettings.Database}];";

        }

        private async Task _initTables()
        {

        }
    }
}
