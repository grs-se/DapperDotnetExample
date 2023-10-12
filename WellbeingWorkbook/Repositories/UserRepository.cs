using Dapper;
using WellbeingWorkbook.Entities;
using WellbeingWorkbook.Helpers;

namespace WellbeingWorkbook.Repositories
{

    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        //Task Create(CreateRequest model);
        //Task Update(int id, UpdateRequest model);
        //Task Delete(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var sql = """
                SELECT * FROM Users
                """;
            return await connection.QueryAsync<User>(sql);
        }

        public async Task<User> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = """
                SELECT * FROM Users
                WHERE Id = @id
                """;
            return await connection.QuerySingleOrDefaultAsync<User>(sql, new { id });
        }
    }
}
