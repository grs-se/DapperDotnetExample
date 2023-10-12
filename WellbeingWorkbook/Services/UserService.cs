using WellbeingWorkbook.Entities;
using WellbeingWorkbook.Repositories;

namespace WellbeingWorkbook.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        //Task Create(CreateRequest model);
        //Task Update(int id, UpdateRequest model);
        //Task Delete(int id);
    }

    public class UserService : IUserService
    {
        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
        { }
        public async Task<IEnumerable<User>> GetAll() { }

    }
}
