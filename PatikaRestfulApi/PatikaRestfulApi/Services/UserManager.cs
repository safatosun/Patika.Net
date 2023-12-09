using PatikaRestfulApi.Entities.Models;
using PatikaRestfulApi.Repositories.Contracts;
using PatikaRestfulApi.Services.Contracts;

namespace PatikaRestfulApi.Services
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(string name, string password)
        {
          var user = _userRepository.GetByNameAndPassword(name, password);   

            return user;
        }
    }
}
