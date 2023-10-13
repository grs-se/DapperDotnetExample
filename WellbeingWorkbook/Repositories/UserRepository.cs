using Dapper;
using WellbeingWorkbook.Entities;
using WellbeingWorkbook.Helpers;

namespace WellbeingWorkbook.Repositories
{

    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task Create(User user);
        //Task Update(User user);
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

        public async Task<User> GetByEmail(string email)
        {
            using var connection = _context.CreateConnection();
            var sql = """
                SELECT * FROM Users
                WHERE Email = @email
                """;
            return await connection.QuerySingleOrDefaultAsync<User>(sql, new { email });
        }

        public async Task Create(User user)
        {
            using var connection = _context.CreateConnection();
            var sql = """
                INSERT INTO Users (Title, FirstName, LastName, Email, Role, PasswordHash)
                VALUES (@Title @FirstName, @LastName, @Email, @Role, @PasswordHash)
                """;
            await connection.ExecuteAsync(sql, user);
        }
    }
}
