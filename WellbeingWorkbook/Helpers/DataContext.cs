using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System.Data;
using Dapper;

namespace WellbeingWorkbook.Helpers
{
    public class DataContext
    {
        private readonly IOptions<DbSettings> _dbSettings;

        public DataContext(IOptions<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings;
        }

        public IDbConnection CreateConnection()
        {
            return;
        }

        public async Task Init()
        {

        }

        private async Task _initDatabase()
        {

        }

        private async Task _initTables()
        {

        }
    }
}
