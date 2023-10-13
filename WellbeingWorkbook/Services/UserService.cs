using AutoMapper;
using WellbeingWorkbook.Entities;
using WellbeingWorkbook.Helpers;
using WellbeingWorkbook.Models.Users;
using WellbeingWorkbook.Repositories;

namespace WellbeingWorkbook.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task Create(CreateRequest model);
        //Task Update(int id, UpdateRequest model);
        //Task Delete(int id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
                throw new KeyNotFoundException("User not found");

            return user;
        }

        public async Task Create(CreateRequest model)
        {
            // validate
            if (await _userRepository.GetByEmail(model.Email) != null)
                throw new AppException("User with the email '" + model.Email + "' already exists");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            // save user
            await _userRepository.Create(user);
        }
    }
}
